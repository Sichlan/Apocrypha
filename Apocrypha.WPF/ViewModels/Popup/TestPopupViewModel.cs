using System.Windows.Input;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.PopupService;

namespace Apocrypha.WPF.ViewModels.Popup;

public class TestPopupViewModel : IPopupViewModel
{
    public event Action ClosePopup;

    public TestPopupViewModel(IShowGlobalPopupService showGlobalPopupService)
    {
        CancelCommand = new RelayCommand(_ => showGlobalPopupService.ClosePopup());
    }

    public ICommand CancelCommand { get; set; }
}