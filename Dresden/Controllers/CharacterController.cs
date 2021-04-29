using Dresden.ApiModels;
using Dresden.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dresden.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        public readonly DresdenContext _db;
        public CharacterController(DresdenContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<CharacterDto> Get()
        {
            return (from c in _db.Characters
                    join u in _db.Users on c.UserId equals u.Id
                    from cv in _db.CharacterVersions
                        .Where(v => !v.DeleteUtc.HasValue && c.Id == v.CharacterId)
                        .OrderByDescending(v => v.CreateUtc)
                        .Take(1)
                        .DefaultIfEmpty()
                    where !c.DeleteUtc.HasValue
                    select new CharacterDto
                    {
                        UserId = u.Id,
                        CharacterId = c.Id,
                        CharacterVersionId = cv.Id,
                        Name = c.Name,
                        Notes = c.Notes,
                        PhysicalStressBoxes = cv.PhysicalStressBoxes,
                        MentalStressBoxes = cv.MentalStressBoxes,
                        SocialStressBoxes = cv.SocialStressBoxes,
                        BaseRefresh = cv.BaseReferesh,
                        CharacterCreateUtc = c.CreateUtc,
                        CharacterUpdateUtc = c.UpdateUtc,
                        CharacterDeleteUtc = c.DeleteUtc,
                        CharacterVersionCreateUtc = cv.CreateUtc,
                        CharacterVersionDeleteUtc = cv.DeleteUtc,
                        Aspects = cv.Aspects.Where(a => !a.DeleteUtc.HasValue).Select(a => new AspectDto
                        {
                            AspectType = a.AspectType,
                            Name = a.Name
                        }),
                        Skills = cv.Skills.Where(s => !s.DeleteUtc.HasValue).Select(s => new SkillDto
                        {
                            Name = s.Skill.Name,
                            SkillId = s.Id,
                            SkillLevel = s.SkillLevel
                        }),
                        Stunts = cv.Stunts.Where(s => !s.DeleteUtc.HasValue).Select(s => new StuntDto
                        {
                            Name = s.Stunt.Name,
                            Notes = s.Notes,
                            StuntId = s.StuntId
                        }),
                        Consequences = c.Consequences.Where(c => !c.DeleteUtc.HasValue).Select(c => new ConsequenceDto 
                        { 
                            Aspect = c.Aspect,
                            Id = c.Id,
                            StressAmount = c.StressAmount
                        }),
                        TemporaryAspects = c.TemporaryAspects.Where(ta => !ta.DeleteUtc.HasValue).Select(ta => new TemporaryAspectDto
                        {
                            Id = ta.Id,
                            Name = ta.Name
                        })
                    }).AsEnumerable();
        }

        [HttpPost]
        public string AddUserCharacter(CharacterDto character)
        {
            var timestamp = DateTimeOffset.UtcNow;

            var newCharacter = new Character
            {
                UserId = character.UserId,
                Name = character.Name,
                Notes = character.Notes,
                CreateUtc = timestamp,
                CharacterVersions = new List<CharacterVersion>()
            };

            var newCharacterVersion = new CharacterVersion
            {
                PhysicalStressBoxes = character.PhysicalStressBoxes,
                MentalStressBoxes = character.MentalStressBoxes,
                SocialStressBoxes = character.SocialStressBoxes,
                BaseReferesh = character.BaseRefresh,
                CreateUtc = timestamp,
                Aspects = new List<CharacterAspect>(),
                Skills = new List<CharacterSkill>(),
                Stunts = new List<CharacterStunt>()
            };

            foreach (var aspect in character.Aspects)
            {
                newCharacterVersion.Aspects.Add(new CharacterAspect
                {
                    AspectType = aspect.AspectType,
                    Name = aspect.Name,
                    CreateUtc = timestamp
                });
            }

            foreach (var skill in character.Skills)
            {
                newCharacterVersion.Skills.Add(new CharacterSkill
                {
                    SkillId = skill.SkillId,
                    SkillLevel = skill.SkillLevel,
                    CreateUtc = timestamp
                });
            }

            foreach (var stunt in character.Stunts)
            {
                newCharacterVersion.Stunts.Add(new CharacterStunt
                {
                    StuntId = stunt.StuntId,
                    Notes = stunt.Notes,
                    CreateUtc = timestamp
                });
            }

            newCharacter.CharacterVersions.Add(newCharacterVersion);
            _db.Characters.Add(newCharacter);

            _db.SaveChanges();

            return "OK";
        }
    }
}
