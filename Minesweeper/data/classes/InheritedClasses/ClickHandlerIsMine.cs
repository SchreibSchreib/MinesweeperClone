using Minesweeper.data.classes.AbstractClasses;
using System;
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

        }
    }
}
