using Minesweeper.data.classes.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.data.classes
{
    public class WholeSessionData
    {
        public WholeSessionData(int lengthX, int lengthY, Player currentPlayer)
        {
            CurrentPlayer = currentPlayer;
            PlayGround = new FieldGenerator(lengthX, lengthY).PlayGround;
            PlayGround = LogicCheckup.Check(PlayGround);
            Buttons = new ButtonCreator(PlayGround, this).GameButtons;
            FirstClickOfGame = true;
        }


        public Dictionary<string, bool> PlayGround { get; private set; }
        public bool FirstClickOfGame { get; private set; }
        public List<GameButton> Buttons { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public void ToggleFirstClickFalse()
        {
            FirstClickOfGame = false;
        }
    }
}
