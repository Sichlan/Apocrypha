namespace Apocrypha.WPF.ViewModels
{
    public class SpellCardEditorViewModel : BaseViewModel
    {
        private SpellCardViewModel _spellCardViewModel = new SpellCardViewModel();

        public SpellCardViewModel SpellCardViewModel
        {
            get => _spellCardViewModel;
            set
            {
                _spellCardViewModel = value;
                OnPropertyChanged();
            }
        }

        public string SpellName
        {
            get => SpellCardViewModel.SpellName;
            set
            {
                SpellCardViewModel.SpellName = value;
                OnPropertyChanged();
            }
        }
        public string SpellCasterClass
        {
            get => SpellCardViewModel.CasterClass;
            set
            {
                SpellCardViewModel.CasterClass = value;
                OnPropertyChanged();
            }
        }
        public int SpellLevel
        {
            get => SpellCardViewModel.SpellLevel;
            set
            {
                SpellCardViewModel.SpellLevel = value;
                OnPropertyChanged();
            }
        }
        public SpellCardEditorViewModel()
        {
            
        }
    }
}