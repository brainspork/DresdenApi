using System;

namespace Dresden.Models
{
    public class Trapping
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? LastUpdateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public Skill Skill { get; set; }
    }
}