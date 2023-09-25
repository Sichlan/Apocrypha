using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Apocrypha.ModernUi.ViewModels.Common;

public delegate TViewModel CreateViewModel<out TViewModel>() where TViewModel : BaseViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}