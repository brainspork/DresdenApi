using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.ApiModels
{
    public class CharacterVersionDto
    {
        public int CharacterVersionId { get; set; }
        public int PhysicalStressBoxes { get; set; }
        public int MentalStressBoxes { get; set; }
        public int SocialStressBoxes { get; set; }
        public int BaseRefresh { get; set; }
        public IEnumerable<AspectDto> Aspects { get; set; }
        public IEnumerable<SkillDto> Skills { get; set; }
        public IEnumerable<StuntDto> Stunts { get; set; }
    }
}
