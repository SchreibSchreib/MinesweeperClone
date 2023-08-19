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
        public TimeMeasure()
        {
            DispatcherTimer newTimer = new DispatcherTimer();
            _seconds = newTimer;
            _seconds.Tick += Timer_Tick;
        }

        private DispatcherTimer _seconds;
        public int GetSeconds { get; private set; }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            GetSeconds++;
        }

        public void Start()
        {
            _seconds.Start();
        }
    }
}
