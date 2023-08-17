using System.Collections.Generic;
using Minesweeper.data.classes.AbstractClasses;


namespace Minesweeper.data.classes
{
    internal class GridLengthCalculator
    {
        public GridLengthCalculator(List<GameButton> buttons)
        {
            _buttons = buttons;
        }

        private List<GameButton> _buttons;

        public int CalculateX() => int.Parse(_buttons[_buttons.Count-1].Coordinates.AsString.Split(' ')[0]);

        public int CalculateY() => int.Parse(_buttons[_buttons.Count - 1].Coordinates.AsString.Split(' ')[1]);
    }
}
