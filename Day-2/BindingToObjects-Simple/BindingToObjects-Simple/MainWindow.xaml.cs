using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace BindingToObjects_Simple
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee employee;
        public MainWindow()
        {
            InitializeComponent();
            //employee = new Employee(){FirstName = "Magesh", LastName = "Kuppan"};
            
            

        }

        private void BtnBindData_OnClick(object sender, RoutedEventArgs e)
        {
            /*TxtFirstName.DataContext = employee;
            TxtLastName.DataContext = employee;*/
            /*StackDataEntry.DataContext = employee;
            TxtFirstName.SetBinding(TextBox.TextProperty, new Binding()
            {
                Path = new PropertyPath("FirstName")
            });
            TxtLastName.SetBinding(TextBox.TextProperty, new Binding()
            {
                Path = new PropertyPath("LastName")
            });*/
        }

        private void BtnPrintObjectState_OnClick(object sender, RoutedEventArgs e)
        {
            var emp = (Employee) LayoutRoot.Resources["emp"];
            Debug.WriteLine(emp);

        }

        private void BtnChangeObjectState_OnClick(object sender, RoutedEventArgs e)
        {
            var emp = (Employee)LayoutRoot.Resources["emp"];
            emp.FirstName = "Magesh";
            emp.LastName = "Kuppan";
            MessageBox.Show("Object state changed");
        }
    }

    public class Employee : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                TriggerPropertyChanged("FirstName");
            }
        }

        private void TriggerPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                TriggerPropertyChanged("LastName");
            }
        }

        public override string ToString()
        {
            return string.Format("First Name = {0}, Last Name={1}", FirstName, LastName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
