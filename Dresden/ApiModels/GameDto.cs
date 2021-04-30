using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.ApiModels
{
    public class GameDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
    }
}
