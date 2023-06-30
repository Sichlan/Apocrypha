using System;
using System.Windows.Input;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Services.State;
using Apocrypha.ModernUi.ViewModels.Common;
using Apocrypha.ModernUi.ViewModels.Navigation;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IHost _host;

    public ICommand NavigateBackwardsCommand { get; }
    public ICommand NavigateForwardsCommand { get; }

    public NavigableViewModel ActiveViewModel
    {
        get
        {
            return _navigationService.ActiveViewModel;
        }
    }

    public MainViewModel(NavigateBackwardsCommand navigateBackwardsCommand,
        NavigateForwardsCommand navigateForwardsCommand,
        NavigableViewModel fallbackStartViewModel,
        INavigationService navigationService,
        IHost host)
    {
        _navigationService = navigationService;
        _host = host;

        if (_navigationService.ActiveViewModel == null)
            _navigationService.Navigate(fallbackStartViewModel);

        _navigationService.PropertyChanged += (_, _) =>
        {
            OnPropertyChanged(nameof(ActiveViewModel));
        };

        // Commands
        NavigateBackwardsCommand = navigateBackwardsCommand;
        NavigateForwardsCommand = navigateForwardsCommand;
    }

    public void NavigateToPage(Type pageType)
    {
        if (_navigationService != null
            && _host.Services.GetService(pageType) is NavigableViewModel vm)
            _navigationService.Navigate(vm);
    }
}