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
        public ButtonIsMine(Coordinates coordOfButton, Dictionary<string, bool> currentGameField)
            : base(coordOfButton, currentGameField)
        {
            Background = new SolidColorBrush(Colors.Red);
            Content = null;
        }

        protected override void GameButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsClicked)
            {
                MessageBox.Show(this.Coordinates.AsString);
                ClickHandler clickHandler = new ClickHandlerIsMine(this, Field.FirstClickOfGame);
                clickHandler.Handle();
            }
        }
    }
}
