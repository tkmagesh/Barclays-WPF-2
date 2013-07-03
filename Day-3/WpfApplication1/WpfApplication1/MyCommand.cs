using System;
using System.Windows.Input;

namespace WpfApplication1
{
    public class MyCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Func<object, bool> _canExecute;

        public MyCommand(Action<object> action, Func<object,bool> canExecute )
        {
            _action = action;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }
    }
}