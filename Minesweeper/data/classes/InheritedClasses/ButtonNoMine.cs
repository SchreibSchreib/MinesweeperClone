using Minesweeper.data.classes.AbstractClasses;
using System.Collections.Generic;
using System.Windows;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ButtonNoMine : GameButton
    {
        public ButtonNoMine(Coordinates coordOfButton, Dictionary<string, bool> currentGameField, Field fieldInformation)
            : base(coordOfButton, currentGameField)
        {
            FieldInformation = fieldInformation;
        }

        protected Field FieldInformation;

        protected override void GameButton_Click(object sender, RoutedEventArgs e)
        {
            ClickHandler thisButton = new ClickHandlerNoMine(this, Field.FirstClickOfGame);
            BroadSearchAlgorithm broadSearchThisClick = new BroadSearchAlgorithm(this, CurrentGameField, FieldInformation.Buttons);
            thisButton.Handle();
        }
    }
}
