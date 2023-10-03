using ClikerGame.Data;
using ClikerGame.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ClikerGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClickDispatcher _clickDispatcher;
        private readonly TimerDispatcher _timerDispatcher;
        private readonly SoundDispatcher _soundDispatcher;
        private readonly IUserController db;
        private User user;
        private List<ButtonShop> buttonShops;

        public MainWindow()
        {
            InitializeComponent();
            _clickDispatcher = new ClickDispatcher();
            _clickDispatcher.ScoreChange += (s) =>
            {
                tbCounter.Text = s;
                var val = long.Parse(tbCounter.Text);
                if (buttonShops != null && buttonShops.Count > 0)
                {
                    foreach (var bs in buttonShops)
                    {
                        if (val > bs.Price)
                            bs.IsEnabled = true;
                        else
                            bs.IsEnabled = false;
                    }
                }
            };

            _timerDispatcher = new TimerDispatcher(_clickDispatcher);
            _soundDispatcher = new SoundDispatcher();
            db= new UserController();

            //var lb = db?.LeaderBoard(10).ToList();
            var lb = new List<User>();

            var sw = new StartWindow(lb);
            sw.StartClick += (s) =>
            {
                user = new User() { Nickname = s };
                startGrid.Visibility = Visibility.Collapsed;
                _timerDispatcher.Start();
            };
            startGrid.Children.Add(sw);

            var bs = new ButtonShop();
            buttonShops= new List<ButtonShop>();
            buttonShops.Add(bs);
            bs.Click += Bs_Click;
            shopStack.Children.Add(bs);
        }

        private void Bs_Click(ButtonShop obj)
        {
            _clickDispatcher.Shopping(obj);
        }

        private void Cookie_Click(object sender, RoutedEventArgs e)
        {
            _clickDispatcher.Click();
            _soundDispatcher.CookieSound();
        }
    }
}
