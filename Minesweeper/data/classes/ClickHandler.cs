using System.Windows.Threading;

namespace Minesweeper.data.classes
{
    public class ClickHandler
    {
        public ClickHandler(GameButton clickedButton, bool isFirstClick)
        {
            _isFirstClick = isFirstClick;
            _clickedButton = clickedButton;

            if (isFirstClick)
            {
                Field.FirstClickOfGame = false;
            }
        }

        private bool _isFirstClick;
        private GameButton _clickedButton;

        public void Handle()
        {
            if (_isFirstClick)
            {
                TimeMeasure stopWatch = new TimeMeasure(new DispatcherTimer());
            }
            _clickedButton.UpDateButtonInformation();
        }
    }
}
