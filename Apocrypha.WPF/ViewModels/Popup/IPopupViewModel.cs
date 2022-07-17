using System;
using System.Windows.Input;

namespace Apocrypha.WPF.ViewModels.Popup
{
    public interface IPopupViewModel
    {
        event Action ClosePopup;

        ICommand CancelCommand { get; set; }
    }
}