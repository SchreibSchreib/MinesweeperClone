using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _clickedButton.UpDateButtonInformation();
        }
    }
}
