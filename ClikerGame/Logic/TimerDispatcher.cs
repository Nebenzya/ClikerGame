using System;
using System.Timers;
using System.Windows.Threading;

namespace ClikerGame.Logic
{
    internal class TimerDispatcher
    {
        private readonly DispatcherTimer timer;
        private readonly ClickDispatcher _clickDispatcher;

        public TimerDispatcher(ClickDispatcher clickDispatcher)
        {
            timer = new() { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += Timer_Tick;

            _clickDispatcher = clickDispatcher;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _clickDispatcher.TimerTick();
        }

        public void Start() => timer.Start();

        public void Pause() => timer.Stop();
    }
}