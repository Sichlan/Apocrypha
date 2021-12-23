using System.Windows;
using System.Windows.Input;
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
        private WindowState _currentWindowState;

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

            LogoutCommand = new LogoutCommand(_authenticator, logoutCommandRenavigator, _characterStore);
            MinimizeCommand = new RelayCommand(o => MinimizeWindow(o));
            MaximizeCommand = new RelayCommand(o => MaximizeWindow(o));
            CloseCommand = new RelayCommand(o => CloseWindow(o));
        }

        private void CloseWindow(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }

        private void MaximizeWindow(object obj)
        {
            CurrentWindowState = CurrentWindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void MinimizeWindow(object obj)
        {
            CurrentWindowState = WindowState.Minimized;
        }


        public WindowState CurrentWindowState
        {
            get => _currentWindowState;
            set 
            { 
                _currentWindowState = value;
                OnPropertyChanged(nameof(CurrentWindowState));
            }
        }

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;
        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public bool HasActiveCharacter => _characterStore.HasActiveCharacter;
        public AsyncCommandBase UpdateCurrentViewModelCommand { get; }
        public AsyncCommandBase LogoutCommand { get; }
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public bool IsExecutingCommand => UpdateCurrentViewModelCommand?.IsExecuting == true;

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