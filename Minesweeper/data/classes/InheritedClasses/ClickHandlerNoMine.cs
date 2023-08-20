using Minesweeper.data.classes.AbstractClasses;
using System.Collections.Generic;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ClickHandlerNoMine : ClickHandler
    {
        public ClickHandlerNoMine(GameButton clickedButton, WholeSessionData currentSession) : base (clickedButton, currentSession)
        {
        }

        public override void Handle()
        {
            if (_currentSession.FirstClickOfGame)
            {
                _currentSession.ToggleFirstClickFalse();
            }
            _clickedButton.IsClicked = true;
            _currentSession.CurrentPlayer.Points.Add();
            _clickedButton.UpDateButtonInformation();
        }
    }
}
