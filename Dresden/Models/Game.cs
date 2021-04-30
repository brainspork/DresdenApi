using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dresden.Models
{
    public class Game
    {
        public Game()
        {
            PlayerCharacters = new HashSet<Character>();
            NonPlayerCharacters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public int GameManagerId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreateUtc { get; set; }

        public User GameManager { get; set; }
        public ICollection<Character> PlayerCharacters { get; set; }
        public ICollection<Character> NonPlayerCharacters { get; set; }
    }
}
