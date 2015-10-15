using System;
using System.Windows.Input;

namespace AY.Translit.TestApp.Helpers
{
    public class RelayCommand : ICommand
    {
        private readonly Action _command;
        private readonly Action<object> _commandExt;
        private readonly Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action command, Func<bool> canExecute = null)
        {
            if (command == null)
                throw new ArgumentNullException();
            _canExecute = canExecute;
            _command = command;
        }

        public RelayCommand(Action<object> command, Func<bool> canExecute = null)
        {
            if (command == null)
                throw new ArgumentNullException();
            _canExecute = canExecute;
            _commandExt = command;
        }

        public void Execute(object parameter)
        {
            if (_command == null)
                _commandExt(parameter);
            else
                _command();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }
    }
}
