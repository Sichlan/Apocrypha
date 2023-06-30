using System;
using Apocrypha.ModernUi.Services.State;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.Helpers.Commands.Navigation;

public class NavigateBackwardsCommand : IRelayCommand
{
    private readonly INavigationService _navigationService;

    public NavigateBackwardsCommand(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName != nameof(INavigationService.CanGoBack))
                return;

            NotifyCanExecuteChanged();
        };
    }

    public bool CanExecute(object parameter)
    {
        return _navigationService.CanGoBack;
    }

    public void Execute(object parameter)
    {
        _navigationService.TryGoBack();
    }

    public event EventHandler CanExecuteChanged;

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}