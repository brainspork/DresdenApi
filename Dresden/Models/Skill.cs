using System;
using System.Collections.Generic;

namespace Dresden.Models
{
    public class Skill
    {
        public Skill()
        {
            Trappings = new HashSet<Trapping>();
            Stunts = new HashSet<Stunt>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? UpdateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public ICollection<Trapping> Trappings { get; set; }
        public ICollection<Stunt> Stunts { get; set; }
    }
}
