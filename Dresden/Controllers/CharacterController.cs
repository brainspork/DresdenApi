using Dresden.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dresden.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        public readonly DresdenContext _db;
        public CharacterController(DresdenContext db)
        {
            _db = db;
        }

        [HttpPost]
        public string AddUserCharacter()
        {
            return "OK";
        }
    }
}
