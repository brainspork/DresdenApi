using System;

namespace Dresden.Models
{
    public class Consequence
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int StressAmount { get; set; }
        public string Aspect { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public Character Character { get; set; }
    }
}