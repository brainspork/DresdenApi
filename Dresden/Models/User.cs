using System;
using System.Collections.Generic;

namespace Dresden.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? UpdateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
