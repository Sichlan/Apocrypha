using System.Windows.Input;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Services.State;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ViewModels.Navigation;

public class HomeViewModel : NavigableViewModel
{
    public ICommand NavigateToPageCommand { get; }

    public HomeViewModel(INavigationService navigationService, IHost host)
    {
        NavigateToPageCommand = new NavigateToPageCommand(navigationService, host);
    }
}