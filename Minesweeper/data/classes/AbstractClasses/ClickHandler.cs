using System.Windows.Threading;

namespace Minesweeper.data.classes.AbstractClasses
{
    public abstract class ClickHandler
    {
        public ClickHandler(GameButton clickedButton, WholeSessionData currentSession)
        {
            _isFirstClick = currentSession.FirstClickOfGame;
            _clickedButton = clickedButton;
            clickedButton.IsClicked = true;

            if (_isFirstClick)
            {
                currentSession.ToggleFirstClickFalse();
            }
            
        }

        private bool _isFirstClick;
        private GameButton _clickedButton;

        public void Handle()
        {
            _clickedButton.UpDateButtonInformation();
        }
    }
}
