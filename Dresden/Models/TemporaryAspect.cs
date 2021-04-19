using System;

namespace Dresden.Models
{
    public class TemporaryAspect
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public Character Character { get; set; }
    }
}