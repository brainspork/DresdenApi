using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.ApiModels
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class JsonSkillModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<InfoItem> Trappings { get; set; }
        public IEnumerable<InfoItem> Stunts { get; set; }
    }

    public class SkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TrappingModel> Trappings { get; set; }
        public IEnumerable<StuntModel> Stunts { get; set; }
    }

    public class TrappingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class StuntModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class InfoItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
