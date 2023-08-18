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
        }


        public Dictionary<string, bool> PlayGround { get; private set; }
        public static bool FirstClickOfGame = true;
        public List<GameButton> Buttons { get; private set; }
        public Player CurrentPlayer { get; private set; }
    }
}
