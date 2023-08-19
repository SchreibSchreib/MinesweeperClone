using Minesweeper.data.classes.AbstractClasses;
using Minesweeper.data.classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Minesweeper.data.Scores;

namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ClickHandlerIsMine : ClickHandler
    {
        public ClickHandlerIsMine(GameButton clickedButton, WholeSessionData fieldInformation) : base(clickedButton, fieldInformation)
        {

        }


        public override void Handle()
        {
            LeaderBoardWriter.WritePlayerList(_currentSession.CurrentPlayer);
            _clickedButton.IsClicked = true;
            MainWindow backToMain = new MainWindow();
            backToMain.Show();
            Closer.closeWindow(_clickedButton);
        }

    }
}
