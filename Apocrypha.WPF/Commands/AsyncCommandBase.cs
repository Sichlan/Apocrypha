using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.WPF.State;

namespace Apocrypha.WPF.Commands
{
    public abstract class AsyncCommandBase : ICommand, IStateChanger
    {
        private bool _isExecuting;

        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                StateChange?.Invoke();
            }
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return !IsExecuting && CanExecuteAsync(parameter);
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;

            await ExecuteAsync(parameter);

            IsExecuting = false;
        }

        public event Action StateChange;

        public abstract Task ExecuteAsync(object parameter);
        public abstract bool CanExecuteAsync(object parameter);
    }
}