using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Apocrypha.WPF.Annotations;

namespace Apocrypha.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<out TViewModel>() where TViewModel : BaseViewModel;

    /// <summary>
    ///     This is a frame for any other view model that implements base functions like PropertyChanged
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}