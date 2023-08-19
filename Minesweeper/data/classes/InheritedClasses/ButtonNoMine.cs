using Minesweeper.data.classes.AbstractClasses;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ButtonNoMine : GameButton
    {
        public ButtonNoMine(Coordinates coordOfButton, Dictionary<string, bool> currentGameField, WholeSessionData fieldInformation)
            : base(coordOfButton, currentGameField)
        {
            FieldInformation = fieldInformation;
            ThisClickHandler = new ClickHandlerNoMine(this, FieldInformation);
        }

        public ClickHandler ThisClickHandler { get; protected set; }

        protected WholeSessionData FieldInformation;

        protected override void GameButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsClicked && !IsDefused)
            {
                BroadSearchAlgorithm broadSearchThisClick = new BroadSearchAlgorithm(this, CurrentGameField, FieldInformation.Buttons, FieldInformation);
                broadSearchThisClick.CheckForButtonsWithZeroMines();
                broadSearchThisClick.ToggleButtons();
                ThisClickHandler.Handle();
            }
        }
    }
}
