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
            _currentDifficulty = currentDifficulty;
        }

        private Difficulty _currentDifficulty;

        public string Name { get; private set; }
        public Points Points { get; private set; }
        public int GetCalculatedPoints { get; private set; }

        public void CalculateHisPoints()
        {
            GetCalculatedPoints = PointEvaluator.Evaluate(_currentDifficulty.Get, Points.Current);
        }
    }
}
