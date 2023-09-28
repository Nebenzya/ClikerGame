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
        public int[] priceModification = { 25, 25 };//цена покупки

        public void ClickСookie() //счетчик кликов
        {
            clickСounter += click;
        }
        public void ModificationDoubleСlick() //умножение клика х2, [0]
        {
            if (clickСounter >= priceModification[0])
            {
                click *= 2;
                clickСounter -= priceModification[0];
                priceModification[0] += priceModification[0];// подорожание покупки х2 клика, можно придумать формулу посложнее
            }
        }
        public void AutoClick()//авто клик каждое n-время, [1]
        {

        }
    }
}