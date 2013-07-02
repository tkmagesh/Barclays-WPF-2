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

namespace ObjectBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SalaryCalculator calculator;

        public MainWindow()
        {
            InitializeComponent();
            calculator = (SalaryCalculator) this.Resources["calculator"];
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            calculator.Calculate();
        }
    }
}
