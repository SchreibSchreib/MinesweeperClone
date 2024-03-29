﻿using System;
using System.Windows.Threading;

namespace Minesweeper.data.classes
{
    public class TimeMeasure
    {
        public TimeMeasure()
        {
            DispatcherTimer newTimer = new DispatcherTimer();
            newTimer.Interval = new TimeSpan(0, 0, 1);
            newTimer.Tick += NewTimer_Tick;
            Seconds = newTimer;
        }

        public DispatcherTimer Seconds { get; private set; }
        public int GetSeconds { get; set; }

        private void NewTimer_Tick(object? sender, EventArgs e)
        {
            GetSeconds++;
        }

        public void Stop(Player playerGetsHisTime)
        {
            Seconds.Stop();
            playerGetsHisTime.SecondsNeeded = GetSeconds;
        }
    }
}
