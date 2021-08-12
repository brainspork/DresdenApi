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
                        PhysicalStressTaken = c.PhysicalStressTaken,
                        MentalStressTaken = c.MentalStressTaken,
                        SocialStressTaken = c.SocialStressTaken,
                        BaseRefresh = cv.BaseReferesh,
                        RefreshUsed = c.RefreshUsed,
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
                            Cost = s.Stunt.RefreshCost,
                            Name = s.Stunt.Name,
                            Description = s.Stunt.Description,
                            Notes = s.Notes,
                            StuntId = s.StuntId
                        }),
                        Consequences = c.Consequences.Where(c => !c.DeleteUtc.HasValue).Select(c => new ConsequenceDto 
                        { 
                            Aspect = c.Aspect,
                            Id = c.Id,
                            StressType = c.StressType,
                            StressCategory = c.StressCategory
                        }),
                        TemporaryAspects = c.TemporaryAspects.Where(ta => !ta.DeleteUtc.HasValue).Select(ta => new TemporaryAspectDto
                        {
                            Id = ta.Id,
                            Name = ta.Name
                        })
                    }).AsEnumerable();
        }

        [HttpGet("{id}")]
        public CharacterDto Get(int id)
        {
            return (from c in _db.Characters
                    join u in _db.Users on c.UserId equals u.Id
                    from cv in _db.CharacterVersions
                        .Where(v => !v.DeleteUtc.HasValue && c.Id == v.CharacterId)
                        .OrderByDescending(v => v.CreateUtc)
                        .Take(1)
                        .DefaultIfEmpty()
                    where !c.DeleteUtc.HasValue && c.Id == id
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
                        PhysicalStressTaken = c.PhysicalStressTaken,
                        MentalStressTaken = c.MentalStressTaken,
                        SocialStressTaken = c.SocialStressTaken,
                        BaseRefresh = cv.BaseReferesh,
                        RefreshUsed = c.RefreshUsed,
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
                            SkillId = s.Skill.Id,
                            SkillLevel = s.SkillLevel
                        }),
                        Stunts = cv.Stunts.Where(s => !s.DeleteUtc.HasValue).Select(s => new StuntDto
                        {
                            Cost = s.Stunt.RefreshCost,
                            Name = s.Stunt.Name,
                            Description = s.Stunt.Description,
                            Notes = s.Notes,
                            StuntId = s.StuntId
                        }),
                        Consequences = c.Consequences.Where(c => !c.DeleteUtc.HasValue).Select(c => new ConsequenceDto
                        {
                            Aspect = c.Aspect,
                            Id = c.Id,
                            StressType = c.StressType,
                            StressCategory = c.StressCategory
                        }),
                        TemporaryAspects = c.TemporaryAspects.Where(ta => !ta.DeleteUtc.HasValue).Select(ta => new TemporaryAspectDto
                        {
                            Id = ta.Id,
                            Name = ta.Name
                        })
                    }).FirstOrDefault();
        }

        [HttpPost]
        public string Post(CharacterDto character)
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

        [HttpPut("{id}")]
        public string Put(int id, CharacterVersionDto characterVersion)
        {
            var timestamp = DateTimeOffset.UtcNow;
            var characterInfo = (from c in _db.Characters
                                 join u in _db.Users on c.UserId equals u.Id
                                 from cv in _db.CharacterVersions
                                     .Where(v => !v.DeleteUtc.HasValue && c.Id == v.CharacterId)
                                     .OrderByDescending(v => v.CreateUtc)
                                     .Take(1)
                                     .DefaultIfEmpty()
                                 where !c.DeleteUtc.HasValue && c.Id == id
                                 select new
                                 {
                                     Character = c,
                                     CurrentCharacterVersion = cv
                                 }).FirstOrDefault();

            characterInfo.CurrentCharacterVersion.DeleteUtc = timestamp;

            var newCharacterVersion = new CharacterVersion
            {
                PhysicalStressBoxes = characterVersion.PhysicalStressBoxes,
                MentalStressBoxes = characterVersion.MentalStressBoxes,
                SocialStressBoxes = characterVersion.SocialStressBoxes,
                BaseReferesh = characterVersion.BaseRefresh,
                CreateUtc = timestamp,
                Aspects = new List<CharacterAspect>(),
                Skills = new List<CharacterSkill>(),
                Stunts = new List<CharacterStunt>()
            };

            foreach (var aspect in characterVersion.Aspects)
            {
                newCharacterVersion.Aspects.Add(new CharacterAspect
                {
                    AspectType = aspect.AspectType,
                    Name = aspect.Name,
                    CreateUtc = timestamp
                });
            }

            foreach (var skill in characterVersion.Skills)
            {
                newCharacterVersion.Skills.Add(new CharacterSkill
                {
                    SkillId = skill.SkillId,
                    SkillLevel = skill.SkillLevel,
                    CreateUtc = timestamp
                });
            }

            foreach (var stunt in characterVersion.Stunts)
            {
                newCharacterVersion.Stunts.Add(new CharacterStunt
                {
                    StuntId = stunt.StuntId,
                    Notes = stunt.Notes,
                    CreateUtc = timestamp
                });
            }

            characterInfo.Character.CharacterVersions.Add(newCharacterVersion);

            _db.SaveChanges();

            return "OK";
        }

        [HttpPatch("{id}")]
        public string Patch(int id, CharacterPatchDto character)
        {
            var timestamp = DateTimeOffset.UtcNow;
            var currentCharacter = _db.Characters.Where(c => c.Id == id).FirstOrDefault();

            _db.Entry(currentCharacter).Collection(c => c.Consequences).Load();
            _db.Entry(currentCharacter).Collection(c => c.TemporaryAspects).Load();

            currentCharacter.Name = character.Name;
            currentCharacter.Notes = character.Notes;
            currentCharacter.PhysicalStressTaken = character.PhysicalStressTaken;
            currentCharacter.MentalStressTaken = character.MentalStressTaken;
            currentCharacter.SocialStressTaken = character.SocialStressTaken;
            currentCharacter.RefreshUsed = character.RefreshUsed;
            currentCharacter.UpdateUtc = timestamp;

            foreach(var consequence in character.Consequences)
            {
                var matchingConsequence = currentCharacter.Consequences
                    .Where(c => 
                        c.StressType == consequence.StressType 
                        && c.StressCategory == consequence.StressCategory
                        && c.Aspect == consequence.Aspect
                        && !c.DeleteUtc.HasValue
                     )
                    .FirstOrDefault();

                if (matchingConsequence == null)
                {
                    currentCharacter.Consequences.Add(new Consequence
                    {
                        StressType = consequence.StressType,
                        StressCategory = consequence.StressCategory,
                        Aspect = consequence.Aspect,
                        CreateUtc = timestamp
                    });
                }
            }

            foreach(var consequence in currentCharacter.Consequences.Where(c => !c.DeleteUtc.HasValue))
            {
                var matchingConsequence = character.Consequences
                    .Where(c => 
                        c.StressType == consequence.StressType 
                        && c.StressCategory == consequence.StressCategory
                        && c.Aspect == consequence.Aspect
                     )
                    .FirstOrDefault();

                if (matchingConsequence == null)
                {
                    consequence.DeleteUtc = timestamp;
                }
            }

            foreach (var tempAspect in character.TemporaryAspects)
            {
                var matchingAspect = currentCharacter.TemporaryAspects
                    .Where(t => t.Name == tempAspect.Name && !t.DeleteUtc.HasValue)
                    .FirstOrDefault();

                if (matchingAspect == null)
                {
                    currentCharacter.TemporaryAspects.Add(new TemporaryAspect
                    {
                        Name = tempAspect.Name,
                        CreateUtc = timestamp
                    });
                }
            }

            foreach (var tempAspect in currentCharacter.TemporaryAspects.Where(t => !t.DeleteUtc.HasValue))
            {
                var matchingAspect = character.TemporaryAspects
                    .Where(t => t.Name == tempAspect.Name)
                    .FirstOrDefault();

                if (matchingAspect == null)
                {
                    tempAspect.DeleteUtc = timestamp;
                }
            }

            _db.SaveChanges();

            return "OK";
        }
    }
}
