using Minesweeper.data.classes.AbstractClasses;
using Minesweeper.data.classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ClickHandlerIsMine : ClickHandler
    {
        public ClickHandlerIsMine(GameButton clickedButton, bool isFirstClick) : base(clickedButton, isFirstClick)
        {
            WholeSessionData.FirstClickOfGame = true;
            MainWindow backToMain = new MainWindow();
            backToMain.Show();
            Closer.closeWindow(clickedButton);
        }
    }
}
