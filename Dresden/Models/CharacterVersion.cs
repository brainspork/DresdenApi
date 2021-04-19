using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.Models
{
    public class CharacterVersion
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int PhysicalStressBoxes { get; set; }
        public int MentalStressBoxes { get; set; }
        public int SocialStressBoxes { get; set; }
        public int BaseReferesh { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public Character Character { get; set; }
        public ICollection<CharacterAspect> Aspects { get; set; }
        public ICollection<CharacterSkill> Skills { get; set; }
        public ICollection<CharacterStunt> Stunts { get; set; }
    }
}
