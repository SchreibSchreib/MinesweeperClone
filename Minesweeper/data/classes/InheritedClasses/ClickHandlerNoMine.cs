using Minesweeper.data.classes.AbstractClasses;
using System.Collections.Generic;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ClickHandlerNoMine : ClickHandler
    {
        public ClickHandlerNoMine(GameButton clickedButton, WholeSessionData currentSession) : base (clickedButton, currentSession)
        {
            currentSession.CurrentPlayer.Points.Add();
        }
    }
}
