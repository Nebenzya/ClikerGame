using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClikerGame.Data;
using ClikerGame.Logic;
using System.Windows.Media.Animation;

namespace ClikerGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClickDispatcher clickDispatcher;
        private TimerDispatcher timerDispatcher;
        private List<ButtonShop> buttonShops;
        private SoundDispatcher soundDispatcher;
            public MainWindow()
            {
                  InitializeComponent();

            ButtonShop button1 = new ButtonShop();
            ButtonShop button2 = new ButtonShop();
            ButtonShop button3 = new ButtonShop();
            ButtonShop button4 = new ButtonShop();
            ButtonShop button5 = new ButtonShop();
            ButtonShop button6 = new ButtonShop();
            ButtonShop button7 = new ButtonShop();
            ButtonShop button8 = new ButtonShop();
            shopStack.Children.Add(button1);
            shopStack.Children.Add(button2);
            shopStack.Children.Add(button3);
            shopStack.Children.Add(button4);
            shopStack.Children.Add(button5);
            shopStack.Children.Add(button6);
            shopStack.Children.Add(button7);
            shopStack.Children.Add(button8);

            clickDispatcher = new();
                var a = clickDispatcher.clickСounter;
            soundDispatcher = new SoundDispatcher();
            }
        
        private void cookie_Click(object sender, RoutedEventArgs e)
        {
            clickDispatcher.ClickСookie();
            cookie_counter.Content = clickDispatcher.clickСounter.ToString();
            soundDispatcher.CookieSound();
            
        }
    }
}
