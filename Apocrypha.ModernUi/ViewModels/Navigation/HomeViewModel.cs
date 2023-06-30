using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;

namespace Apocrypha.ModernUi.ViewModels.Navigation;

public class HomeViewModel : NavigableViewModel
{
    public override string ViewModelTitle { get; } = Localization.HomeViewModelTitle;

    public HomeViewModel(NavigateToPageCommand navigateToPageCommand)
        : base(navigateToPageCommand)
    {
    }
}