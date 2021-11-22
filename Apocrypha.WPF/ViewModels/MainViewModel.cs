using System.Windows.Input;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Navigators.Authenticators;
using Apocrypha.WPF.State.Navigators.Navigators;
using Apocrypha.WPF.ViewModels.Factories;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IApocryphaViewModelFactory _viewModelFactory;

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;
        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(IAuthenticator authenticator, INavigator navigator, IApocryphaViewModelFactory viewModelFactory)
        {
            _authenticator = authenticator;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            
            _navigator.StateChange += Navigator_StateChange;
            _authenticator.StateChange += Authenticator_StateChange;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }

        private void Authenticator_StateChange()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_StateChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}