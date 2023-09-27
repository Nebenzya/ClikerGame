using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClikerGame.Logic
{
    internal class ClickDispatcher
    {
        public long click = 1;//кол-во за нажатие
        public long clickСounter = 0;//счетчик
        public int priceModification = 25;//цена покупки

        public void ClickСookie() //счетчик кликов
        {
            clickСounter += click;
        }
        public void ModificationDoubleСlick() //умножение клика х2
        {
            if (clickСounter >= priceModification)
            {
                click *= 2;
                clickСounter -= priceModification;
                priceModification += priceModification;// подорожание покупки х2 клика, можно придумать формулу посложнее
            }
        }
    }
}