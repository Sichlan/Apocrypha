using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.PopupService;
using Apocrypha.WPF.ViewModels.Popup;

namespace Apocrypha.WPF.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IShowGlobalPopupService _showGlobalPopupService;

        public HomeViewModel(IShowGlobalPopupService showGlobalPopupService)
        {
            _showGlobalPopupService = showGlobalPopupService;
            TestPopupCommand = new RelayCommand(o => _showGlobalPopupService.ShowPopup(new TestPopupViewModel(_showGlobalPopupService)));
        }

        public RelayCommand TestPopupCommand { get; set; }
    }
}