using Minesweeper.data.classes.AbstractClasses;
using System.Collections.Generic;
using System.Windows;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ButtonNoMine : GameButton
    {
        public ButtonNoMine(Coordinates coordOfButton, Dictionary<string, bool> currentGameField, WholeSessionData fieldInformation)
            : base(coordOfButton, currentGameField)
        {
            FieldInformation = fieldInformation;
        }

        protected WholeSessionData FieldInformation;

        protected override void GameButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.Coordinates.AsString);
            ClickHandler thisButton = new ClickHandlerNoMine(this, FieldInformation);
            BroadSearchAlgorithm broadSearchThisClick = new BroadSearchAlgorithm(this, CurrentGameField, FieldInformation.Buttons, FieldInformation);
            broadSearchThisClick.CheckForButtonsWithZeroMines();
            broadSearchThisClick.ToggleButtons();
            thisButton.Handle();
        }
    }
}
