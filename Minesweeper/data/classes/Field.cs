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
            playGround = new FieldGenerator().GenerateFieldMap(lengthX, lengthY);
        }
        public static bool firstClick = true;

        public Dictionary<string, bool> playGround;
    }
}
