using Minesweeper.data.classes.AbstractClasses;
using System.Collections.Generic;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ClickHandlerNoMine : ClickHandler
    {
        public ClickHandlerNoMine(GameButton clickedButton, bool isFirstClick, WholeSessionData currentSession) : base (clickedButton, isFirstClick)
        {
            currentSession.CurrentPlayer.Points.Add();
        }
    }
}
