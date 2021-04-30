using Dresden.ApiModels;
using Dresden.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController
    {
        public readonly DresdenContext _db;
        public GameController(DresdenContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<GameDto> Get(int userId)
        {
            return _db.Games
                .Include(g => g.PlayerCharacters)
                .Where(g => g.GameManagerId == userId || g.PlayerCharacters.Any(c => c.UserId == userId))
                .Select(g => new GameDto
                {
                    UserId = g.GameManagerId,
                    Name = g.Name,
                    CreateUtc = g.CreateUtc
                }).AsEnumerable();
        }

        [HttpPost]
        public string Post(GameDto game)
        {
            _db.Games.Add(new Game
            {
                GameManagerId = game.UserId,
                Name = game.Name,
                CreateUtc = DateTimeOffset.UtcNow
            });

            return "OK";
        }
    }
}
