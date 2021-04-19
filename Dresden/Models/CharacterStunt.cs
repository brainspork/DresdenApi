using System;

namespace Dresden.Models
{
    public class CharacterStunt
    {
        public int Id { get; set; }
        public int CharacterVersionId { get; set; }
        public int StuntId { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public CharacterVersion CharacterVersion { get; set; }
        public Stunt Stunt { get; set; }
    }
}