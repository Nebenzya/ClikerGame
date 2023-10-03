using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClikerGame.Logic
{
    internal class ClickDispatcher
    { 
        private long _score = default;
        private long deltaClick = 1, deltaTick = 1;

        public Action<string>? ScoreChange;
        public long ClickCount { get; private set; }
        public long Score 
        { 
            get 
            {
                return _score; 
            } 
            
            private set 
            {
                _score = value;
                ScoreChange?.Invoke(_score.ToString());
            } 
        }


        public void Click() //счетчик кликов
        {
            Score += deltaClick;
            ClickCount++;
        }

        public void TimerTick()
        {
            Score += deltaTick;
        }

        public void Shopping(ButtonShop bs)
        {
            Score -= bs.Price;
            deltaClick++;
        }
    }
}