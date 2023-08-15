using Minesweeper.data.classes;
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
        }
        public static bool firstClick = true;

        public Dictionary<string, bool> PlayGround { get; private set; }
    }
}
