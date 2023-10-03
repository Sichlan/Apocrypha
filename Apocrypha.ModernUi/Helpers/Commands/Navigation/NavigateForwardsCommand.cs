using System;
using Apocrypha.ModernUi.Services.State.Navigation;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.Helpers.Commands.Navigation;

public class NavigateForwardsCommand : IRelayCommand
{
    private readonly INavigationService _navigationService;

    public NavigateForwardsCommand(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName != nameof(INavigationService.CanGoForward))
                return;

            NotifyCanExecuteChanged();
        };
    }

    public bool CanExecute(object parameter)
    {
        return _navigationService.CanGoForward;
    }

    public void Execute(object parameter)
    {
        _navigationService.TryGoForward();
    }

    public event EventHandler CanExecuteChanged;

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}