using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ClikerGame
{

    public partial class StartWindow : UserControl
    {
        public Action<string>? StartClick;

        public StartWindow(List<Data.User>? users)
        {
            InitializeComponent();
            LoginTextBox.Foreground = Brushes.LightGray;

            if (users != null && users.Count > 0)
                foreach (var user in users)
                    RatingTextBlock.Text += $"{user?.Nickname}: {user?.Score}\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            StartClick?.Invoke(login);
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
