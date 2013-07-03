using System.ComponentModel;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    public class Employee : INotifyPropertyChanged
    {
        private string _id;
        private string _firstName;
        private string _lastName;

        public string Id
        {
            get { return _id; }
            set { 
                _id = value; 
                OnPropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; 
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName");}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return string.Format("Id = {0}, First Name={1}, Last Name={2}", Id, FirstName, LastName);
        }
    }
}