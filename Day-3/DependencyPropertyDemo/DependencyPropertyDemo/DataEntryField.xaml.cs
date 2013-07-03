using System.Windows;
using System.Windows.Controls;

namespace DependencyPropertyDemo
{
    /// <summary>
    /// Interaction logic for DataEntryField.xaml
    /// </summary>
    public partial class DataEntryField : UserControl
    {
        private string _caption;
        private string _value;

        public DataEntryField()
        {
            InitializeComponent();
        }



        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(DataEntryField), new UIPropertyMetadata("Field Name",new PropertyChangedCallback(CaptionChanged )));

        private static void CaptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (DataEntryField) d;
            ctl.label1.Content = e.NewValue;

        }




        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(DataEntryField), new UIPropertyMetadata(string.Empty, new PropertyChangedCallback(ValueChanged)));

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctl = (DataEntryField)d;
            ctl.textBox1.Text = e.NewValue.ToString();
        }


        /*public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                label1.Content = value;
            }
        }

        public string Value
        {
            get { return textBox1.Text; }
            set
            {
                _value = value;
                textBox1.Text = value;
            }
        }*/
    }
}
