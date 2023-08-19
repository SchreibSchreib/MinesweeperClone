using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes
{
    public static class PointEvaluator
    {
        public static int Evaluate(string difficulty, int points, int time)
        {
            switch (difficulty)
            {
                case ("easy"):
                    return points * (750 - time) * (int)Difficulty.Rank.easy;
                case ("hard"):
                    return points * (1000 - time) * (int)Difficulty.Rank.hard;
                default:
                    return points * (900 - time) * (int)Difficulty.Rank.medium;
            }

        }
    }
}
