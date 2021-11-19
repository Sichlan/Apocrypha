using System.ComponentModel;
using System.Runtime.CompilerServices;
using Apocrypha.WPF.Annotations;

namespace Apocrypha.WPF.ViewModels
{
    /// <summary>
    /// This is a frame f9or any other view model that implements base functions like PropertyChanged
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}