using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;
using Apocrypha.ModernUi.ViewModels.Navigation;

namespace Apocrypha.ModernUi.ViewModels.Editor;

public class EditorHomeViewModel : NavigableViewModel
{
    public override string ViewModelTitle { get; } = Localization.EditorHomeViewModelTitle;

    public EditorHomeViewModel(NavigateToPageCommand navigateToPageCommand)
        : base(navigateToPageCommand)
    {
    }
}