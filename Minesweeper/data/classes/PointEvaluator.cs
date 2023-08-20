namespace Minesweeper.data.classes
{
    public static class PointEvaluator
    {
        public static int Evaluate(string difficulty, int points, int time)
        {
            switch (difficulty)
            {
                case ("Easy"):
                    return points * (250 - (time + 1) / 5) * (int)Difficulty.Rank.easy;
                case ("Hard"):
                    return points * (250 - (time + 1) / 5) * (int)Difficulty.Rank.hard;
                default:
                    return points * (250 - (time + 1) / 5) * (int)Difficulty.Rank.medium;
            }

        }
    }
}
