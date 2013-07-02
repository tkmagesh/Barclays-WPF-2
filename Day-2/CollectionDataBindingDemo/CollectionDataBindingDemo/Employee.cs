using System.ComponentModel;

namespace CollectionDataBindingDemo
{
    public class Employee : INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                TriggerPropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                TriggerPropertyChanged("FirstName");
            }
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
            return string.Format("Id  = {0}, FirstName = {1}, LastName = {2}", Id, FirstName, LastName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void TriggerPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                TriggerPropertyChanged(propertyName);
        }
    }
}