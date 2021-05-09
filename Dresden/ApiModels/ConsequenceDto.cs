using Dresden.Models;

namespace Dresden.ApiModels
{
    public class ConsequenceDto
    {
        public int Id { get; set; }
        public StressType StressType { get; set; }
        public string Aspect { get; set; }
    }
}