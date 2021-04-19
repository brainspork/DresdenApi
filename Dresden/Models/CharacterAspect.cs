using System;

namespace Dresden.Models
{
    public enum AspectType
    {
        HighConcept,
        Trouble,
        Other
    }

    public class CharacterAspect
    {
        public int Id { get; set; }
        public int CharacterVersionId { get; set; }
        public AspectType AspectType { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public CharacterVersion CharacterVersion { get; set; }
    }
}