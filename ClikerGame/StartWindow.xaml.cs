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
using System.Windows.Shapes;

namespace ClikerGame
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            //Тут будет запрос к БД
            MainWindow mainW = new MainWindow();
            mainW.Show();
        }

        private void RatingButton_Click(object sender, RoutedEventArgs e)
        {
            RatingWindow raitingW = new RatingWindow();
            raitingW.Show();
        }
    }
}
