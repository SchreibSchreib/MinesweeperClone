using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Minesweeper.data.classes
{
    public class TimeMeasure
    {
        public TimeMeasure(DispatcherTimer newTimer)
        {
            _seconds = newTimer;
            _seconds
        }

        private DispatcherTimer _seconds;
        public int timeInSeconds
    }
}
