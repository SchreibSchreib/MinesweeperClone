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
            PlayGround = LogicCheckup.Check(PlayGround);
        }
        public List<GameButton> Buttons { get; private set; }
        public Dictionary<string, bool> PlayGround { get; private set; }

        public static bool FirstClickOfGame = true;

        private List<GameButton> CreateButtons()
        {
            List<GameButton> buttons = new List<GameButton>();
            foreach (KeyValuePair<string, bool> kvp in PlayGround)
            {
                int xCoords = int.Parse(kvp.Key.Split(' ')[0]);
                int yCoords = int.Parse(kvp.Key.Split(' ')[1]);
                //more Logic for Buttons who inherit from abstract class GameButton
            }
            return buttons;
        }
    }
}
