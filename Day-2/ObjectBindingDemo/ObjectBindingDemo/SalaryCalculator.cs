using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ObjectBindingDemo
{
    public class SalaryCalculator : INotifyPropertyChanged
    {
        private double _basic;
        private double _hra;
        private double _da;
        private double _tax;
        private double _salary;

        public double Basic
        {
            get { return _basic; }
            set
            {
                _basic = value;
                TriggerPropertyChanged("Basic");
            }
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
            }
        }

        public double Da
        {
            get { return _da; }
            set
            {
                _da = value;
                TriggerPropertyChanged("Da");
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

        public void Calculate()
        {
            var net = Basic + Hra + Da;
            var taxable = net*(Tax/100);
            Salary = net - taxable;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
