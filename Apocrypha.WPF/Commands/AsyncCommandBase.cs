using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.WPF.State.Navigators;

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

        public event Action StateChange;

        public abstract Task ExecuteAsync(object parameter);
    }
}