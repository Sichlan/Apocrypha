using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apocrypha.WPF.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        public bool IsExecuting { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;

            await ExecuteAsync(parameter);

            IsExecuting = false;
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}