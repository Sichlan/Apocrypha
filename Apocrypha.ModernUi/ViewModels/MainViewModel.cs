using Apocrypha.ModernUi.Services.State;
using Apocrypha.ModernUi.ViewModels.Common;
using Apocrypha.ModernUi.ViewModels.Navigation;

namespace Apocrypha.ModernUi.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    public NavigableViewModel ActiveViewModel
    {
        get
        {
            return _navigationService.ActiveViewModel;
        }
    }

    public MainViewModel(INavigationService navigationService, NavigableViewModel fallbackStartViewModel)
    {
        _navigationService = navigationService;

        if (_navigationService.ActiveViewModel == null)
            _navigationService.Navigate(fallbackStartViewModel);

        _navigationService.PropertyChanged += (_, _) => OnPropertyChanged(nameof(ActiveViewModel));
    }
}