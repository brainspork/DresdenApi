using System;

namespace Dresden.Models
{
    public enum StressType
    {
        Mild = 2,
        Moderate = 4,
        Severe = 6,
        Extreme = 8
    }

    public class Consequence
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public StressType StressType { get; set; }
        public string Aspect { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public Character Character { get; set; }
    }
}