using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;

namespace Apocrypha.ModernUi.ViewModels.Navigation.Editor;

public class EditorHomeViewModel : NavigableViewModel
{
    public override string ViewModelTitle { get; } = Localization.EditorHomeViewModelTitle;

    public EditorHomeViewModel(NavigateToPageCommand navigateToPageCommand)
        : base(navigateToPageCommand)
    {
    }
}