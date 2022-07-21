using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.WPF.State.PopupService;
using Apocrypha.WPF.ViewModels.Popup;

namespace Apocrypha.WPF.Commands.Translation
{
    public class TranslateObjectCommand<T> : AsyncCommandBase where T : Translation<T>, new()
    {
        private readonly ITranslatable<T> _translatable;
        private readonly IShowGlobalPopupService _showGlobalPopupService;

        public TranslateObjectCommand(ITranslatable<T> translatable, IShowGlobalPopupService showGlobalPopupService)
        {
            _translatable = translatable;
            _showGlobalPopupService = showGlobalPopupService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _showGlobalPopupService.ShowPopup(new TranslationEditorPopupViewModel<T>(_translatable, _showGlobalPopupService));
        }

        public override bool CanExecuteAsync(object parameter)
        {
            return _translatable != null;
        }
    }
}