using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.ApiModels
{
    public class CharacterPatchDto
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public int? PhysicalStressTaken { get; set; }
        public int? MentalStressTaken { get; set; }
        public int? SocialStressTaken { get; set; }
        public int? RefreshUsed { get; set; }
        public IEnumerable<ConsequenceDto> Consequences { get; set; }
        public IEnumerable<TemporaryAspectDto> TemporaryAspects { get; set; }
    }
}
