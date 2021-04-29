using System;

namespace Dresden.ApiModels
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset CreateUtc { get; set; }
        public DateTimeOffset? UpdateUtc { get; set; }
        public DateTimeOffset? DeleteUtc { get; set; }
    }
}
