using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;

namespace Apocrypha.ModernUi.ViewModels.Navigation;

public class TestViewModel : NavigableViewModel
{
    public override string ViewModelTitle { get; } = Localization.TestViewModelTitle;

    public TestViewModel(NavigateToPageCommand navigateToPageCommand)
        : base(navigateToPageCommand)
    {
    }
}