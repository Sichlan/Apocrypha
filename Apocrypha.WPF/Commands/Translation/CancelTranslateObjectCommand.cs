using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.WPF.State.PopupService;

namespace Apocrypha.WPF.Commands.Translation
{
    public class CancelTranslateObjectCommand<T> : AsyncCommandBase where T : Translation<T>, new()
    {
        private readonly IShowGlobalPopupService _showGlobalPopupService;

        public CancelTranslateObjectCommand(IShowGlobalPopupService showGlobalPopupService)
        {
            _showGlobalPopupService = showGlobalPopupService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            //TODO: Ask user if cancellation is intended
            await _showGlobalPopupService.ClosePopup();
        }

        public override bool CanExecuteAsync(object parameter)
        {
            return true;
        }
    }
}