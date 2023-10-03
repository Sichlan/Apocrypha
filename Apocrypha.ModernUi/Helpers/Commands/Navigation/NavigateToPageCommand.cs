using System;
using System.Windows.Input;
using Apocrypha.ModernUi.Services.State.Navigation;
using Apocrypha.ModernUi.ViewModels.Navigation;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.Helpers.Commands.Navigation;

public class NavigateToPageCommand : ICommand
{
    private readonly INavigationService _navigationService;
    private readonly IHost _host;

    public NavigateToPageCommand(INavigationService navigationService, IHost host)
    {
        _navigationService = navigationService;
        _host = host;
    }

    public bool CanExecute(object parameter)
    {
        return _navigationService != null
               && ((parameter is Type t
                    && _host.Services.GetService(t) is NavigableViewModel)
                   || parameter is NavigableViewModel);
    }

    public void Execute(object parameter)
    {
        if (parameter is Type t && _host.Services.GetService(t) is NavigableViewModel vm)
            _navigationService.Navigate(vm);
        else if (parameter is NavigableViewModel viewModel)
            _navigationService.Navigate(viewModel);
    }

    public event EventHandler CanExecuteChanged;
}