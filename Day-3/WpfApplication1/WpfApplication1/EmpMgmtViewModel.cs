using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    public class EmpMgmtViewModel : INotifyPropertyChanged
    {
        private bool _showModelWindow;
        public ObservableCollection<Employee> Employees { get; private set; }

        public EmpMgmtViewModel()
        {
            NewEmployee = new Employee();
            Employees = new ObservableCollection<Employee>()
                {
                    new Employee(){Id = "101", FirstName = "Magesh", LastName = "K"},
                    new Employee(){Id = "102", FirstName = "Suresh", LastName = "K"},
                };
            AddNewEmployee = new MyCommand(o =>
                {
                    ShowModelWindow = true;

                }, o => true);
            /*SaveEmployeeCommand = new MyCommand(o => HideAddEmployeeWindow()
                , o => true);*/
        }

        public void HideAddEmployeeWindow()
        {
            
                Employees.Add(NewEmployee);
                NewEmployee = new Employee();
                ShowModelWindow = false;
            
        }
        public bool ShowModelWindow
        {
            get { return _showModelWindow; }
            set
            {
                _showModelWindow = value;
                OnPropertyChanged("ShowModelWindow");
            }
        }

        /*public ICommand SaveEmployeeCommand { get; set; }*/

        public bool ShowAddWindow { get; set; }

        public Employee NewEmployee { get; set; }

        public ICommand AddNewEmployee { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
