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
            _seconds.Start();
            _seconds.Tick += Timer_Tick;
        }

        private DispatcherTimer _seconds;
        public int TimeInSeconds = 0;

        private void Timer_Tick(object? sender, EventArgs e)
        {
            TimeInSeconds++;
        }


    }
}
