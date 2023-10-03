using System;
using System.Windows;
using System.Windows.Controls;

namespace ClikerGame
{
    /// <summary>
    /// Логика взаимодействия для ButtonShop.xaml
    /// </summary>
    public partial class ButtonShop : UserControl
    {
        private long _count = 0, _price = 10;
        public event Action<ButtonShop>? Click;
        public long Price { get => _price; private set => _price = value; }
        public ButtonShop()
        {
            InitializeComponent();
            lbPrice.Content = _price.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _count++;
            lbCount.Content = _count.ToString();
            Click?.Invoke(this);
            _price *= 2;
            lbPrice.Content = _price.ToString();
        }


    }
}
