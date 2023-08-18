using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public class Player
    {
        public Player(string name, Points pointsForThisPlayer, Difficulty currentDifficulty)
        {

            Name = name;
            Points = pointsForThisPlayer;
            CurrentDifficulty = currentDifficulty;
        }

        public Difficulty CurrentDifficulty { get; private set; }
        public string Name { get; private set; }
        public Points Points { get; private set; }

        public int CalculateHisPoints() => PointEvaluator.Evaluate(CurrentDifficulty.Get, Points.Current);
    }
}
