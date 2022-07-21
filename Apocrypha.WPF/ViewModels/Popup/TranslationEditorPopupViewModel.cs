using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.WPF.Commands.Translation;
using Apocrypha.WPF.State.PopupService;

namespace Apocrypha.WPF.ViewModels.Popup
{
    public class TranslationEditorPopupViewModel<T> : BaseViewModel, IPopupViewModel where T : Translation<T>, new()
    {
        private readonly ITranslatable<T> _translatable;
        private readonly IShowGlobalPopupService _showGlobalPopupService;
        private readonly ObservableCollection<T> _newTranslationCollection;

        public TranslationEditorPopupViewModel(ITranslatable<T> translatable, IShowGlobalPopupService showGlobalPopupService)
        {
            _translatable = translatable;
            _showGlobalPopupService = showGlobalPopupService;
            _newTranslationCollection = new ObservableCollection<T>(_translatable.Translations.Copy());

            SetCommands();
            UpdateTranslations();
        }

        private void UpdateTranslations()
        {
            OnPropertyChanged(nameof(NewTranslationCollection));
        }

        private void SetCommands()
        {
            CancelCommand = new CancelTranslateObjectCommand<T>(_showGlobalPopupService);
        }

        public ICommand CancelCommand { get; set; }

        public event Action ClosePopup;


        public ObservableCollection<T> NewTranslationCollection
        {
            get
            {
                return _newTranslationCollection;
            }
        }

        public ITranslatable<T> Translatable
        {
            get
            {
                return _translatable;
            }
        }
    }
}