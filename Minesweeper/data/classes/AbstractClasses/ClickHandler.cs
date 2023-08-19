using System.Windows.Threading;

namespace Minesweeper.data.classes.AbstractClasses
{
    public abstract class ClickHandler
    {
        public ClickHandler(GameButton clickedButton, WholeSessionData currentSession)
        {
            _currentSession = currentSession;
            _clickedButton = clickedButton;           
        }

        protected WholeSessionData _currentSession;
        protected GameButton _clickedButton;

        public abstract void Handle();
    }
}
