using System;
using System.Collections.Generic;

namespace Dresden.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? UpdateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public ICollection<CharacterVersion> CharacterVersions { get; set; }
        public ICollection<Consequence> Consequences { get; set; }
        public ICollection<TemporaryAspect> TemporaryAspects { get; set; }
    }
}
