using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper.data.classes
{
    public class Difficulty
    {
        public Difficulty() 
        {
            Get = "medium";
        }
        public Difficulty(CheckBox difficultyCheckBox)
        {
            Get = difficultyCheckBox.Name;
        }

        public string Get { get; private set; }

        public enum Rank { easy = 1, medium, hard }
    }
}
