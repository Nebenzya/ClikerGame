using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ClikerGame.Logic
{
    internal class TimerDispatcher
    {
        public int sec, min, hour;//сек, мин, час
        public System.Timers.Timer timer;

        public void GameTime()//Подсчет времени игры
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += GameTimeEvent;
        }
        public void GameTimeEvent(Object source, ElapsedEventArgs e)//ивент для GameTime()
        {
            sec += 1;
            if (sec == 60)
            {
                min += 1;
                sec = 0;
            }
            if (min == 60)
            {
                min = 0;
                hour += 1;
            }
        }
    }
}