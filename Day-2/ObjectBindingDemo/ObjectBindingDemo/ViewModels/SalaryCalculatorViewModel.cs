using System.ComponentModel;
using System.Windows.Input;
using ObjectBindingDemo.Models;

namespace ObjectBindingDemo.ViewModels
{
    public class SalaryCalculatorViewModel : INotifyPropertyChanged
    {
        private double _basic;
        private double _hra;
        private double _da;
        private double _tax;
        private double _salary;
        private bool _isSalaryCalculatable;
        private SalaryCalculator calculator;
        private ICommand _calculateSalaryCommand;
        private double _gross;
        private ICommand _calculateGross;

        public SalaryCalculatorViewModel()
        {
            calculator = new SalaryCalculator();
            /*_calculateSalaryCommand = new CalculateSalaryCommand(this);
            _calculateGross = new CalculateGrossCommand(this);*/
            _calculateSalaryCommand = new MyCommand(o => this.Calculate(), o=> true);
            _calculateGross = new MyCommand(o => this.CalculateGrossSalary(), o => true);
        }
        public double Basic
        {
            get { return _basic; }
            set
            {
                _basic = value;
                TriggerPropertyChanged("Basic");
                UpdateIsSalaryCalculatable();
            }
        }

        private void UpdateIsSalaryCalculatable()
        {
            IsSalaryCalculatable = (Basic > 0 && Hra > 0 && Da > 0);
        }

        private void TriggerPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public double Hra
        {
            get { return _hra; }
            set
            {
                _hra = value;
                TriggerPropertyChanged("Hra");
                UpdateIsSalaryCalculatable();
            }
        }

        public double Da
        {
            get { return _da; }
            set
            {
                _da = value;
                TriggerPropertyChanged("Da");
                UpdateIsSalaryCalculatable();
            }
        }

        public double Tax
        {
            get { return _tax; }
            set { 
                _tax = value; 
                TriggerPropertyChanged("Tax");
            }
        }

        public double Salary
        {
            get { return _salary; }
            private set
            {
                _salary = value;
                TriggerPropertyChanged("Salary");
            }
        }

        public bool IsSalaryCalculatable
        {
            get { return _isSalaryCalculatable; }
            private set
            {
                _isSalaryCalculatable = value;
                TriggerPropertyChanged("IsSalaryCalculatable");
            }
        }

        public void Calculate()
        {
            Salary = calculator.CalculateSalary(Basic, Hra, Da, Tax);
        }

        public ICommand CalculateSalary
        {
            get { return _calculateSalaryCommand; }
            set
            {
                _calculateSalaryCommand = value;
                TriggerPropertyChanged("CalculateSalary");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CalculateGrossSalary()
        {
            Gross = Basic + Hra + Da;
        }

        public double Gross
        {
            get { return _gross; }
            set
            {
                _gross = value;
                TriggerPropertyChanged("Gross");
            }
        }

        public ICommand CalculateGross
        {
            get { return _calculateGross; }
            set { _calculateGross = value; }
        }
    }

    /*public class CalculateGrossCommand : ICommand
    {
        private readonly SalaryCalculatorViewModel _viewModel;

        public CalculateGrossCommand(SalaryCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Execute(object parameter)
        {
           _viewModel.CalculateGrossSalary();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public event EventHandler CanExecuteChanged;
    }

    public class CalculateSalaryCommand : ICommand
    {
        private readonly SalaryCalculatorViewModel _viewModel;

        public CalculateSalaryCommand(SalaryCalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Execute(object parameter)
        {
            _viewModel.Calculate();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }*/
}