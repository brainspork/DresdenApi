using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.ApiModels
{
    public class CharacterDto
    {
        public int UserId { get; set; }
        public int CharacterId { get; set; }
        public int CharacterVersionId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int PhysicalStressBoxes { get; set; }
        public int MentalStressBoxes { get; set; }
        public int SocialStressBoxes { get; set; }
        public int? PhysicalStressTaken { get; set; }
        public int? MentalStressTaken { get; set; }
        public int? SocialStressTaken { get; set; }
        public int BaseRefresh { get; set; }
        public int? RefreshUsed { get; set; }
        public IEnumerable<AspectDto> Aspects { get; set; }
        public IEnumerable<SkillDto> Skills { get; set; }
        public IEnumerable<StuntDto> Stunts { get; set; }
        public IEnumerable<ConsequenceDto> Consequences { get; set; }
        public IEnumerable<TemporaryAspectDto> TemporaryAspects { get; set; }
        public DateTimeOffset CharacterCreateUtc { get; set; }
        public DateTimeOffset? CharacterUpdateUtc { get; set; }
        public DateTimeOffset? CharacterDeleteUtc { get; set; }
        public DateTimeOffset CharacterVersionCreateUtc { get; set; }
        public DateTimeOffset? CharacterVersionDeleteUtc { get; set; }
    }
}
