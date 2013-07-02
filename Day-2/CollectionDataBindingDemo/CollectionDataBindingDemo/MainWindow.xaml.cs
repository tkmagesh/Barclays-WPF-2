using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CollectionDataBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> employees;

        public MainWindow()
        {
            InitializeComponent();
            employees = new ObservableCollection<Employee>
                {
                    new Employee() {Id = 11, FirstName = "Magesh", LastName = "Kuppan"},
                    new Employee() {Id = 12, FirstName = "Suresh", LastName = "Kannan"},
                    new Employee() {Id = 31, FirstName = "Ganesh", LastName = "Easwar"},
                    new Employee() {Id = 41, FirstName = "Yuva", LastName = "Kuppan"},
                    new Employee() {Id = 17, FirstName = "Rajesh", LastName = "Pandit"},
                    new Employee() {Id = 13, FirstName = "Ramesh", LastName = "Jayram"}
                };
        }

        private void BtnShowAllEmployees_OnClick(object sender, RoutedEventArgs e)
        {
            ListEmployees.DataContext = employees;
        }

        private void BtnAddNewEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            employees.Add(new Employee()
                {
                    Id = 201,
                    FirstName = "Jeeva",
                    LastName = "Kuppan"
                });
            MessageBox.Show("New employee added " + employees.Count.ToString() + " employees are there now!!!");

        }

        private void BtnRemoveSelected_OnClick(object sender, RoutedEventArgs e)
        {
            var employeeToDelete = (Employee) ListEmployees.SelectedItem;
            employees.Remove(employeeToDelete);
            MessageBox.Show("Existing employee removed.  " + employees.Count.ToString() + " employees are there now!!!");
        }

        private void BtnRemoveEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button) sender;
            var empToDelete = (Employee) btn.DataContext;
            employees.Remove(empToDelete);
        }
    }
}
