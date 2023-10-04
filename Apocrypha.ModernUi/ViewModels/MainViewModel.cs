using System;
using System.Windows.Input;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Services.State.Navigation;
using Apocrypha.ModernUi.ViewModels.Common;
using Apocrypha.ModernUi.ViewModels.Display.Users;
using Apocrypha.ModernUi.ViewModels.Navigation;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IHost _host;
    private bool _showUserPopup;
    private UserPopupViewModel _userPopupViewModel;

    public ICommand NavigateBackwardsCommand { get; }
    public ICommand NavigateForwardsCommand { get; }
    public ICommand ToggleUserPopupCommand { get; }

    public NavigableViewModel ActiveViewModel
    {
        get
        {
            return _navigationService.ActiveViewModel;
        }
    }

    public bool ShowUserPopup
    {
        get
        {
            return _showUserPopup;
        }
        set
        {
            if (value == _showUserPopup)
                return;

            _showUserPopup = value;
            OnPropertyChanged();
        }
    }

    public UserPopupViewModel UserPopupViewModel
    {
        get
        {
            return _userPopupViewModel;
        }
        set
        {
            if (Equals(value, _userPopupViewModel))
                return;

            _userPopupViewModel = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CurrentUserName));
        }
    }

    public string CurrentUserName
    {
        get
        {
            return UserPopupViewModel?.CurrentUser?.Username ?? "TEMP NOT LOGGED IN";
        }
    }

    public MainViewModel(NavigateBackwardsCommand navigateBackwardsCommand,
        NavigateForwardsCommand navigateForwardsCommand,
        NavigableViewModel fallbackStartViewModel,
        INavigationService navigationService,
        IHost host,
        UserPopupViewModel userPopupViewModel)
    {
        _navigationService = navigationService;
        _host = host;

        if (_navigationService.ActiveViewModel == null)
            _navigationService.Navigate(fallbackStartViewModel);

        _navigationService.PropertyChanged += (_, _) =>
        {
            OnPropertyChanged(nameof(ActiveViewModel));
        };

        UserPopupViewModel = userPopupViewModel;
        UserPopupViewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(UserPopupViewModel.CurrentUser))
            {
                OnPropertyChanged(nameof(UserPopupViewModel));
                OnPropertyChanged(nameof(CurrentUserName));
            }
        };

        // Commands
        NavigateBackwardsCommand = navigateBackwardsCommand;
        NavigateForwardsCommand = navigateForwardsCommand;
        ToggleUserPopupCommand = new RelayCommand(ExecuteToggleUserPopupCommand, CanExecuteToggleUserPopupCommand);
    }

    private bool CanExecuteToggleUserPopupCommand()
    {
        return true;
    }

    private void ExecuteToggleUserPopupCommand()
    {
        ShowUserPopup = !ShowUserPopup;
    }

    public void NavigateToPage(Type pageType)
    {
        if (_navigationService != null
            && _host.Services.GetService(pageType) is NavigableViewModel vm)
            _navigationService.Navigate(vm);
    }
}