using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Minesweeper.data.classes.AbstractClasses;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ButtonIsMine : GameButton
    {
        public ButtonIsMine(Coordinates coordOfButton, Dictionary<string, bool> currentGameField, WholeSessionData fieldInformation)
            : base(coordOfButton, currentGameField)
        {
            FieldInformation = fieldInformation;
            Background = new SolidColorBrush(Colors.Red);
            ThisClickHandler = new ClickHandlerIsMine(this, FieldInformation);
            Content = null;
        }

        public ClickHandler ThisClickHandler { get; protected set; }

        protected WholeSessionData FieldInformation;

        protected override void GameButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsClicked && !IsDefused)
            {
                ThisClickHandler.Handle();
            }
        }
    }
}
