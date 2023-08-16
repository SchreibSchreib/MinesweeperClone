using Minesweeper.data.classes.AbstractClasses;
using System.Collections.Generic;
using System.Windows;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ButtonNoMine : GameButton
    {
        public ButtonNoMine(Coordinates coordOfButton, Dictionary<string, bool> currentGameField)
            : base(coordOfButton, currentGameField)
        {

        }

        protected override void GameButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler thisButton = new ClickHandlerNoMine(this, Field.FirstClickOfGame);
            BroadSearchAlgorithm broadSearchThisClick = new BroadSearchAlgorithm(this, CurrentGameField, Field.Buttons);
            thisButton.Handle();
        }
    }
}
