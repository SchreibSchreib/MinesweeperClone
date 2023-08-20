using System.Text.Json.Serialization;

namespace Minesweeper.data.classes
{
    public class Difficulty
    {
        [JsonConstructor]
        public Difficulty()
        {
            Get = "Medium";
        }

        public Difficulty(string difficulty)
        {
            Get = difficulty;
        }

        public string Get { get; set; }

        public enum Rank { easy = 1, medium, hard }
    }
}
