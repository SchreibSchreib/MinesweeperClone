using Minesweeper.data.classes.AbstractClasses;
using Minesweeper.data.classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Minesweeper.data.Scores;
using System.Windows;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ClickHandlerIsMine : ClickHandler
    {
        public ClickHandlerIsMine(GameButton clickedButton, WholeSessionData fieldInformation) : base(clickedButton, fieldInformation)
        {

        }


        public override void Handle()
        {
            MainWindow backToMain = new MainWindow();
            backToMain.Show();
            Closer.closeWindow(_clickedButton);
        }

    }
}
