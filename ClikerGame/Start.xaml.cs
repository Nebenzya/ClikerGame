using ClikerGame.Data;
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
using static ClikerGame.Data.UserModel;

namespace ClikerGame
{

    public partial class Start : UserControl
    {
        IUserController User = new UserController();
        IUserController db = new UserController();

        public Start()
        {
            InitializeComponent();
            LoginTextBox.Foreground = SystemColors.GrayTextBrush;

            var users = db.LeaderBoard(10);
            foreach (var user in users)
            {
                RatingTextBlock.Text += $"{user?.Nickname}: {user?.Score}\n";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            var newUser = User.GetUser(login);

            MainWindow mainW = new MainWindow();
            mainW.Show();
        }

        private void nameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "Введите ваше имя")
            {
                LoginTextBox.Text = "";
                LoginTextBox.Foreground = SystemColors.WindowTextBrush;
            }
        }

        private void nameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                LoginTextBox.Text = "Введите ваше имя";
                LoginTextBox.Foreground = SystemColors.GrayTextBrush;
            }
        }

    }
}
