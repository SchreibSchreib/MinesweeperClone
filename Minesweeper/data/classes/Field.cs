using Minesweeper.data.classes.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.data.classes
{
    public class Field
    {
        public Field(int lengthX, int lengthY)
        {
            PlayGround = new FieldGenerator(lengthX, lengthY).PlayGround;
            PlayGround = LogicCheckup.Check(PlayGround);
            _buttons = new ButtonCreator(PlayGround).GameButtons;
        }


        public Dictionary<string, bool> PlayGround { get; private set; }
        public static bool FirstClickOfGame = true;

        private static List<GameButton> _buttons = new List<GameButton>();

        public static List<GameButton> Buttons
        {
            get { return _buttons; }
            private set { _buttons = value; }

        }
    }
}
