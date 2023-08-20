namespace Minesweeper.data.classes
{
    public class FieldLength
    {
        public FieldLength(Difficulty currentDifficulty)
        {
            _difficulty = currentDifficulty;
            Set();
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public int MaxNeighbourMines { get; private set; }

        private Difficulty _difficulty;

        private void Set()
        {
            string difficulty = _difficulty.Get;

            switch (difficulty)
            {
                case "Easy":
                    X = 15;
                    Y = 15;
                    MaxNeighbourMines = 2;
                    break;
                case "Medium":
                    X = 35;
                    Y = 35;
                    MaxNeighbourMines = 3;
                    break;
                default:
                    X = 80;
                    Y = 40;
                    MaxNeighbourMines = 3;
                    break;
            }
        }
    }
}