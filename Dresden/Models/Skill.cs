using System.Collections.Generic;

namespace Dresden.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Trapping> Trappings { get; set; }
        public ICollection<Stunt> Stunts { get; set; }
    }
}
