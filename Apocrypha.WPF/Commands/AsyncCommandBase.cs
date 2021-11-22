using Apocrypha.WPF.State.Navigators;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apocrypha.WPF.Commands
{
    public abstract class AsyncCommandBase : ICommand, IStateChanger
    {
        private bool _isExecuting;
        public bool IsExecuting 
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                StateChange?.Invoke();
            }
        }

        public event EventHandler CanExecuteChanged;
        public event Action StateChange;

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