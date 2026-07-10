using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonApp.ViewModels
{
    public class RelayCommand : ICommand
    {
        Func<object?, bool> _canExecute;
        Func<object?, Task> _execute;

        public RelayCommand(Func<object?, Task> execute, Func<object?, bool>? canExecute=null)
        {
            _execute = execute;
            _canExecute = canExecute!=null ? canExecute: (o=>true);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);

        }
    }
}
