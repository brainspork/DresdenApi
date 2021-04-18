using Dresden.ApiModels;
using Dresden.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.Controllers.Manual
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        public readonly DresdenContext _db;
        public SkillController(DresdenContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<SkillModel> Get()
        {
            return _db.Skills
                .Select(s => new SkillModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Trappings = _db.Trappings.Where(t => t.Skill.Id == s.Id).Select(t => new TrappingModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Description = t.Description
                    }).AsEnumerable(),
                    Stunts = _db.Stunts.Where(st => st.Skill.Id == s.Id).Select(st => new StuntModel
                    {
                        Id = st.Id,
                        Name = st.Name,
                        Description = st.Description
                    }).AsEnumerable()
                }).AsEnumerable();
        }

        [HttpGet("{id}")]
        public SkillModel Get(int id)
        {
            return _db.Skills
                 .Where(s => s.Id == id)
                 .Select(s => new SkillModel
                 {
                     Id = s.Id,
                     Name = s.Name,
                     Description = s.Description,
                     Trappings = _db.Trappings.Where(t => t.Skill.Id == s.Id).Select(t => new TrappingModel
                     {
                         Id = t.Id,
                         Name = t.Name,
                         Description = t.Description
                     }).AsEnumerable(),
                     Stunts = _db.Stunts.Where(st => st.Skill.Id == s.Id).Select(st => new StuntModel
                     {
                         Id = st.Id,
                         Name = st.Name,
                         Description = st.Description
                     }).AsEnumerable()
                 }).FirstOrDefault();
        }

        [HttpPatch]
        public string Patch(IEnumerable<JsonSkillModel> skills)
        {
            try
            {
                foreach (var skill in skills)
                {
                    var existingSkill = _db.Skills.Where(s => s.Name == skill.Name).FirstOrDefault();
                    if (existingSkill != null)
                    {
                        existingSkill.Name = skill.Name;
                        existingSkill.Description = skill.Description;
                    }
                    else
                    {
                        var newSkill = new Skill
                        {
                            Name = skill.Name,
                            Description = skill.Description,
                            Trappings = new List<Trapping>(),
                            Stunts = new List<Stunt>()
                        };

                        _db.Skills.Add(newSkill);

                        existingSkill = newSkill;
                    }

                    foreach (var trapping in skill.Trappings)
                    {
                        var existingTrapping = _db.Trappings.Where(t => t.Name == trapping.Name && t.Skill.Id == existingSkill.Id).FirstOrDefault();
                        if (existingTrapping != null)
                        {
                            existingTrapping.Name = trapping.Name;
                            existingTrapping.Description = trapping.Description;
                        }
                        else
                        {
                            existingSkill.Trappings.Add(new Trapping
                            {
                                Name = trapping.Name,
                                Description = trapping.Description
                            });
                        }
                    }

                    foreach (var stunt in skill.Stunts)
                    {
                        var existingStunt = _db.Stunts.Where(t => t.Name == stunt.Name && t.Skill.Id == existingSkill.Id).FirstOrDefault();
                        if (existingStunt != null)
                        {
                            existingStunt.Name = stunt.Name;
                            existingStunt.Description = stunt.Description;
                        }
                        else
                        {
                            existingSkill.Stunts.Add(new Stunt
                            {
                                Name = stunt.Name,
                                Description = stunt.Description
                            });
                        }
                    }
                }

                _db.SaveChanges();

                return "OK";
            }
            catch
            {
                return "Error";
            }
        }
    }
}
