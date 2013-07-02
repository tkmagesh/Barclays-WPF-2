using System;
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

        public SalaryCalculatorViewModel()
        {
            calculator = new SalaryCalculator();
            _calculateSalaryCommand = new CalculateSalaryCommand(this);
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
    }
}