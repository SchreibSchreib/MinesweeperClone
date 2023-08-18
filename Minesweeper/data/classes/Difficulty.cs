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
        public Difficulty(CheckBox difficultyCheckBox)
        {
            GetDifficulty = difficultyCheckBox.Name;
        }

        public string GetDifficulty { get; private set; }

        public enum Rank { easy = 1, medium, hard }
    }
}
