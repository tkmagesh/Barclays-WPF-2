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
using System.Windows.Shapes;

namespace MyFirstWPFApp
{
    /// <summary>
    /// Interaction logic for ControlToControlSynchronization.xaml
    /// </summary>
    public partial class ControlToControlSynchronization : Window
    {
        public ControlToControlSynchronization()
        {
            InitializeComponent();
            /*this.textBlock1.SetBinding(TextBlock.TextProperty,
                                       new Binding() {Source = this.textBox1, Path = new PropertyPath("Text")});*/
            /*this.textBlock1.SetBinding(TextBlock.TextProperty,
                                       new Binding() { ElementName = "textBox1", Path = new PropertyPath("Text") });*/
        }
    }
}
