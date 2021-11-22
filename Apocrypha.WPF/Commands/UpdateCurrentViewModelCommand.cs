using System.Threading;
using System.Threading.Tasks;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Navigators.Navigators;
using Apocrypha.WPF.ViewModels.Factories;

namespace Apocrypha.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : AsyncCommandBase
    {
        private readonly INavigator _navigator;
        private readonly IApocryphaViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IApocryphaViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is ViewType type)
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(type);
        }
    }
}