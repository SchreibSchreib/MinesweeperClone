using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    internal class PointEvaluater
    {
        public PointEvaluater(Points currentPoints, string difficulty)
        {
            _currentPoints = currentPoints;
            _stringDifficulty = difficulty;
        }

        private Points _currentPoints;
        private string _stringDifficulty;


        public int Evaluate()
        {
            switch (_stringDifficulty)
            {
                case ("easy"):
                    return _currentPoints.CurrentPoints * (750 - TimeMeasure.TimeInSeconds) * (int)Difficulty.Rank.easy;
                case ("hard"):
                    return _currentPoints.CurrentPoints * (1000 - TimeMeasure.TimeInSeconds) * (int)Difficulty.Rank.hard;
                default:
                    return _currentPoints.CurrentPoints * (900 - TimeMeasure.TimeInSeconds) * (int)Difficulty.Rank.medium;
            }

        }
    }
}
