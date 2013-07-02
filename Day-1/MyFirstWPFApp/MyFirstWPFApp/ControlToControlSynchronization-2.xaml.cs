using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// <summary>e
    /// Interaction logic for ControlToControlSynchronization_2.xaml
    /// </summary>
    public partial class ControlToControlSynchronization_2 : Window
    {
        public ControlToControlSynchronization_2()
        {
            InitializeComponent();
            this.textBlock1.SetBinding(TextBlock.TextProperty,
                                       new Binding()
                                           {
                                               Source = this.slider1,
                                               Path = new PropertyPath("Value"),
                                               StringFormat = "##"
                                           });

            /*var converter = new SliderValueToForegroundBrushConverter();
            this.textBlock1.SetBinding(TextBlock.ForegroundProperty, new Binding()
                {
                    Source = this.slider1,
                    Path = new PropertyPath("Value"),
                    Converter = converter
                });*/
        }
    }

    public class SliderValueToForegroundBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tax = (double) value;
            if (tax > 30) return Brushes.Red;
            return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
