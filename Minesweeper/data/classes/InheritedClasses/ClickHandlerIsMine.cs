using Minesweeper.data.classes.AbstractClasses;


namespace Minesweeper.data.classes.InheritedClasses
{
    internal class ClickHandlerIsMine : ClickHandler
    {
        public ClickHandlerIsMine(GameButton clickedButton, WholeSessionData fieldInformation) : base(clickedButton, fieldInformation)
        {

        }


        public override void Handle()
        {
        }

    }
}
