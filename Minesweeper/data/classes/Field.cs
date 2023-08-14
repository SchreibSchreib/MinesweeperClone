using Minesweeper.data.classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper
{
    public class Field
    {
        public Field(int lengthX, int lengthY)
        {
            FieldGenerator mapCreation = new FieldGenerator(lengthX, lengthY);
            playGround = new FieldGenerator(lengthX, lengthY).PlayGround;
        }
        public static bool firstClick = true;

        public Dictionary<string, bool> playGround;
    }
}
