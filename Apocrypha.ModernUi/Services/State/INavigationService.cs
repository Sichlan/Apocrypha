using System.ComponentModel;
using System.Threading.Tasks;
using Apocrypha.ModernUi.ViewModels.Navigation;

namespace Apocrypha.ModernUi.Services.State;

public interface INavigationService : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public NavigableViewModel ActiveViewModel { get; }

    public void Navigate(NavigableViewModel target);
    public Task NavigateAsync(NavigableViewModel target);
    public bool CanGoBack();
    public void GoBack();
    public bool TryGoBack();
    public Task GoBackAsync();
    public Task<bool> TryGoBackAsync();
    public bool CanGoForward();
    public void GoForward();
    public bool TryGoForward();
    public Task GoForwardAsync();
    public Task<bool> TryGoForwardAsync();
}