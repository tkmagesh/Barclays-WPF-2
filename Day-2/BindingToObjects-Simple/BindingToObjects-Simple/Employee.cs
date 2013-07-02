using System.ComponentModel;

namespace BindingToObjects_Simple
{
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