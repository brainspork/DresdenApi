using System;

namespace Dresden.Models
{
    public class CharacterSkill
    {
        public int Id { get; set; }
        public int CharacterVersionId { get; set; }
        public int SkillId { get; set; }
        public int SkillLevel { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public CharacterVersion CharacterVersion { get; set; }
        public Skill Skill { get; set; }
    }
}