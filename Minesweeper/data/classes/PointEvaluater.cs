using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    internal class PointEvaluater
    {
        public PointEvaluater(string difficulty)
        {
            _stringDifficulty = difficulty;
        }

        private string _stringDifficulty;


        public int Evaluate()
        {
            switch (_stringDifficulty)
            {
                case ("easy"):
                    return Points.CurrentPoints * (750 - TimeMeasure.TimeInSeconds) * (int)Difficulty.Rank.easy;
                case ("hard"):
                    return Points.CurrentPoints * (1000 - TimeMeasure.TimeInSeconds) * (int)Difficulty.Rank.hard;
                default:
                    return Points.CurrentPoints * (900 - TimeMeasure.TimeInSeconds) * (int)Difficulty.Rank.medium;
            }

        }
    }
}
