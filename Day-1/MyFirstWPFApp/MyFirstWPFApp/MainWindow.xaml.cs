using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFirstWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            if (TxtUserName.Text.Equals(PwdPassword.Password))
            {
                TbStatus.Text = "Login attemp successful";
                TbStatus.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                TbStatus.Text = "User credentials are invalid";
                TbStatus.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
