using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Minesweeper.data.classes.AbstractClasses;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ButtonIsMine : GameButton
    {
        public ButtonIsMine(Coordinates coordOfButton, Dictionary<string, bool> currentGameField)
            : base(coordOfButton, currentGameField)
        {

        }

        protected override void GameButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsClicked)
            {
                ClickHandler clickHandler = new ClickHandlerIsMine(this, Field.FirstClickOfGame);
                clickHandler.Handle();
            }
        }
    }
}
