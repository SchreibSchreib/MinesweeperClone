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
            if (_currentSession.FirstClickOfGame)
            {
                _currentSession.ToggleFirstClickFalse();
                _currentSession.RefreshPlayGround(_clickedButton.Coordinates.AsString);
                _clickedButton.Behaviour = false;
                _clickedButton.IsClicked = true;
            }
            _clickedButton.UpDateButtonInformation();
        }
    }
}
