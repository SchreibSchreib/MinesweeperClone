using Minesweeper.data.classes.AbstractClasses;
using System.Collections.Generic;

namespace Minesweeper.data.classes
{
    public class WholeSessionData
    {
        public WholeSessionData(Player currentPlayer)
        {
            CurrentPlayer = currentPlayer;
            _currentFieldLength = new FieldLength(CurrentPlayer.CurrentDifficulty);
            PlayGround = new FieldGenerator(_currentFieldLength.X, _currentFieldLength.Y).PlayGround;
            PlayGround = LogicCheckup.Check(PlayGround, _currentFieldLength.MaxNeighbourMines);
            Buttons = new ButtonCreator(PlayGround, this).GameButtons;
            FirstClickOfGame = true;
        }


        public Dictionary<string, bool> PlayGround { get; private set; }
        public bool FirstClickOfGame { get; private set; }
        public List<GameButton> Buttons { get; private set; }
        public Player CurrentPlayer { get; private set; }

        private FieldLength _currentFieldLength;

        public void ToggleFirstClickFalse()
        {
            FirstClickOfGame = false;
        }

        public void RefreshPlayGround(string nameOfButton)
        {
            PlayGround[nameOfButton] = false;
        }
    }
}
