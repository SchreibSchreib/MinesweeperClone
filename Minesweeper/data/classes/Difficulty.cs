using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;

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
