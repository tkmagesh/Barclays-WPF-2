using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using CollectionDataBindingDemo.Annotations;

namespace CollectionDataBindingDemo
{
    public class EmployeeMgmtViewModel : INotifyPropertyChanged
    {
        private ICommand _showAllEmployeesCommand;
        private ObservableCollection<Employee> _employees;
        private ICommand _addNewEmployeeCommand;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public EmployeeMgmtViewModel()
        {
            
            _showAllEmployeesCommand = new MyCommand(o =>
                {
                    Employees = new ObservableCollection<Employee>
                {
                    new Employee() {Id = 11, FirstName = "Magesh", LastName = "Kuppan"},
                    new Employee() {Id = 12, FirstName = "Suresh", LastName = "Kannan"},
                    new Employee() {Id = 31, FirstName = "Ganesh", LastName = "Easwar"},
                    new Employee() {Id = 41, FirstName = "Yuva", LastName = "Kuppan"},
                    new Employee() {Id = 17, FirstName = "Rajesh", LastName = "Pandit"},
                    new Employee() {Id = 13, FirstName = "Ramesh", LastName = "Jayram"}
                };        
                }, o => true);

            _addNewEmployeeCommand =
                new MyCommand(
                    o => Employees.Add(new Employee() {Id = 2001, FirstName = "FirstName", LastName = "LastName"}),
                    o => true);

        }

        public ICommand ShowAllEmployeesCommand
        {
            get { return _showAllEmployeesCommand; }
        }

        public ICommand AddNewEmployeeCommand
        {
            get { return _addNewEmployeeCommand; }
            set { _addNewEmployeeCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
