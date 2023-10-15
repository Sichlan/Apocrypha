using System.Windows.Input;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.ViewModels.Common;

namespace Apocrypha.ModernUi.ViewModels.Navigation;

public abstract class NavigableViewModel : BaseViewModel
{
    /// <summary>
    /// The title of the view model that is automatically displayed in the UI. If the view model itself defines no title, "NOT LOCALIZED" serves both as a fallback and a reminder.
    /// </summary>
    public virtual string ViewModelTitle { get; } = "NOT LOCALIZED";

    public ICommand NavigateToPageCommand { get; }

    protected NavigableViewModel(NavigateToPageCommand navigateToPageCommand)
    {
        NavigateToPageCommand = navigateToPageCommand;
    }

    public virtual void OnNavigateTo() { }
    public virtual void OnNavigateFrom() { }
}