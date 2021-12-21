using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Navigators.Authenticators;
using Apocrypha.WPF.State.Navigators.Navigators;
using Apocrypha.WPF.ViewModels.Factories;

namespace Apocrypha.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IAuthenticator _authenticator;
        private readonly ICharacterStore _characterStore;
        private readonly INavigator _navigator;
        private readonly IApocryphaViewModelFactory _viewModelFactory;

        private bool _menuExpanded;

        public MainViewModel(IAuthenticator authenticator, INavigator navigator, IApocryphaViewModelFactory viewModelFactory,
            IRenavigator logoutCommandRenavigator, ICharacterStore characterStore)
        {
            _authenticator = authenticator;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _characterStore = characterStore;

            _navigator.StateChange += Navigator_StateChange;
            _authenticator.StateChange += Authenticator_StateChange;
            _characterStore.StateChange += CharacterStore_StateChange;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
            UpdateCurrentViewModelCommand.StateChange += UpdateCurrentViewModelCommand_StateChange;

            LogoutCommand = new LogoutCommand(_authenticator, logoutCommandRenavigator);
        }

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;
        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public bool HasActiveCharacter => _characterStore.HasActiveCharacter;
        public AsyncCommandBase UpdateCurrentViewModelCommand { get; }
        public AsyncCommandBase LogoutCommand { get; }
        public bool IsExecutingCommand => UpdateCurrentViewModelCommand?.IsExecuting == true;

        public string Title => "Apocrypha";

        public bool MenuExpanded
        {
            get => _menuExpanded;
            set
            {
                _menuExpanded = value;
                OnPropertyChanged();
            }
        }


        private void UpdateCurrentViewModelCommand_StateChange()
        {
            OnPropertyChanged(nameof(IsExecutingCommand));
        }

        private void Authenticator_StateChange()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_StateChange()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void CharacterStore_StateChange()
        {
            OnPropertyChanged(nameof(HasActiveCharacter));
        }
    }
}