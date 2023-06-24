using System.Windows;
using System.Windows.Input;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State;
using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Popups;
using Apocrypha.WPF.ViewModels.Factories;
using Apocrypha.WPF.ViewModels.Popup;

namespace Apocrypha.WPF.ViewModels;

public class MainViewModel : BaseViewModel
{
    #region Services

    private readonly IAuthenticator _authenticator;
    private readonly ICharacterStore _characterStore;
    private readonly IShowGlobalPopupService _showGlobalPopupService;
    private readonly INavigator _navigator;
    private readonly IApocryphaViewModelFactory _viewModelFactory;
    private readonly IRenavigator _logoutCommandRenavigator;

    #endregion

    #region Fields

    private bool _isMenuExpanded;
    private WindowState _currentWindowState;

    #endregion

    public MainViewModel(IAuthenticator authenticator,
        INavigator navigator,
        IApocryphaViewModelFactory viewModelFactory,
        IRenavigator logoutCommandRenavigator,
        ICharacterStore characterStore,
        IShowGlobalPopupService showGlobalPopupService)
    {
        _authenticator = authenticator;
        _navigator = navigator;
        _viewModelFactory = viewModelFactory;
        _logoutCommandRenavigator = logoutCommandRenavigator;
        _characterStore = characterStore;
        _showGlobalPopupService = showGlobalPopupService;

        SetCommands();
        SetEvents();

        UpdateCurrentViewModelCommand.Execute(ViewType.Login);
    }

    #region EventHandler

    private void SetEvents()
    {
        _navigator.StateChange += Navigator_StateChange;
        _authenticator.StateChange += Authenticator_StateChange;
        _characterStore.StateChange += CharacterStore_StateChange;
        _showGlobalPopupService.StateChange += ShowGlobalPopupServiceOnStateChange;
        UpdateCurrentViewModelCommand.StateChange += UpdateCurrentViewModelCommand_StateChange;
    }

    private void UpdateCurrentViewModelCommand_StateChange()
    {
        OnPropertyChanged(nameof(IsExecutingCommand));
    }

    private void ShowGlobalPopupServiceOnStateChange()
    {
        OnPropertyChanged(nameof(PopupVisibility));
        OnPropertyChanged(nameof(PopupViewModel));
    }

    private void CharacterStore_StateChange()
    {
        OnPropertyChanged(nameof(HasActiveCharacter));
        CommandManager.InvalidateRequerySuggested();
    }

    private void Authenticator_StateChange()
    {
        OnPropertyChanged(nameof(IsLoggedIn));
    }

    private void Navigator_StateChange()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

    #endregion

    #region Commands

    public AsyncCommandBase UpdateCurrentViewModelCommand { get; private set; }
    public AsyncCommandBase LogoutCommand { get; private set; }
    public ICommand MinimizeCommand { get; private set; }
    public ICommand MaximizeCommand { get; private set; }
    public ICommand CloseCommand { get; private set; }

    private void SetCommands()
    {
        UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory, this);
        LogoutCommand = new LogoutCommand(_authenticator, _logoutCommandRenavigator, _characterStore);
        MinimizeCommand = new RelayCommand(_ => MinimizeWindow());
        MaximizeCommand = new RelayCommand(_ => MaximizeWindow());
        CloseCommand = new RelayCommand(o => CloseWindow(o));
    }

    private static void CloseWindow(object obj)
    {
        if (obj is Window window)
        {
            window.Close();
        }
    }

    private void MaximizeWindow()
    {
        CurrentWindowState = CurrentWindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
    }

    private void MinimizeWindow()
    {
        CurrentWindowState = WindowState.Minimized;
    }

    #endregion

    #region Properties

    public WindowState CurrentWindowState
    {
        get
        {
            return _currentWindowState;
        }
        set
        {
            _currentWindowState = value;
            OnPropertyChanged(nameof(CurrentWindowState));
        }
    }

    public BaseViewModel CurrentViewModel
    {
        get
        {
            return _navigator.CurrentViewModel;
        }
    }

    public bool IsLoggedIn
    {
        get
        {
            return _authenticator.IsLoggedIn;
        }
    }

    public bool HasActiveCharacter
    {
        get
        {
            return _characterStore.HasActiveCharacter;
        }
    }

    public bool IsExecutingCommand
    {
        get
        {
            return UpdateCurrentViewModelCommand?.IsExecuting == true;
        }
    }

    public bool IsMenuExpanded
    {
        get
        {
            return _isMenuExpanded;
        }
        set
        {
            _isMenuExpanded = value;
            OnPropertyChanged();
        }
    }

    public Visibility PopupVisibility
    {
        get
        {
            return _showGlobalPopupService?.IsVisible == true ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    public IPopupViewModel PopupViewModel
    {
        get
        {
            return _showGlobalPopupService?.PopupViewModel;
        }
    }

    public string ApplicationTitle
    {
        get
        {
            return Resources.Localization.Localization.ApplicationTitle;
        }
    }

    #endregion
}