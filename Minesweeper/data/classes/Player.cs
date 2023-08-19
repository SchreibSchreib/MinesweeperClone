using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Minesweeper.data.classes
{
    public class Player
    {
        public Player(string name, Points pointsForThisPlayer, Difficulty currentDifficulty)
        {

            Name = name;
            Points = pointsForThisPlayer;
            CurrentDifficulty = currentDifficulty;
            CurrentTimer = new TimeMeasure();
        }

        public Difficulty CurrentDifficulty { get; private set; }
        public string Name { get; private set; }
        public Points Points { get; private set; }
        public TimeMeasure CurrentTimer { get; private set; }

        public int CalculateHisPoints() => PointEvaluator.Evaluate(CurrentDifficulty.Get, Points.Current, CurrentTimer.GetSeconds);
    }
}
