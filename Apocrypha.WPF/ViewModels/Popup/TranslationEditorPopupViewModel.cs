using System;
using System.Windows.Input;

namespace Apocrypha.WPF.ViewModels.Popup
{
    public class TranslationEditorPopupViewModel : IPopupViewModel
    {
        public event Action ClosePopup;


        public ICommand CancelCommand { get; set; }
    }
}