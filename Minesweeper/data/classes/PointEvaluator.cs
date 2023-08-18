using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public static class PointEvaluator
    {
        public static int Evaluate(string difficulty, int points)
        {
            switch (difficulty)
            {
                case ("easy"):
                    return points * (750 - TimeMeasure.TimeInSeconds) * (int)Difficulty.Rank.easy;
                case ("hard"):
                    return points * (1000 - TimeMeasure.TimeInSeconds) * (int)Difficulty.Rank.hard;
                default:
                    return points * (900 - TimeMeasure.TimeInSeconds) * (int)Difficulty.Rank.medium;
            }

        }
    }
}
