using Dresden.ApiModels;
using Dresden.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly DresdenContext _db;
        public UserController(DresdenContext db)
        {
            _db = db;
        }

        [HttpPost]
        public string Post(UserDto user)
        {
            _db.Users.Add(new User
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreateUtc = DateTimeOffset.UtcNow
            });

            _db.SaveChanges();

            return "OK";
        }
    }
}
