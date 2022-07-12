using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Spells;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.Annotations;

namespace Apocrypha.WPF.ViewModels
{
    public class SpellCardEditorViewModel : BaseViewModel
    {
        private SpellCardViewModel _spellCardViewModel;
        private List<SpellSchool> _selectableSpellSchools;

        private readonly IDataService<SpellSchool> _spellSchoolDataService;

        #region SelectionLists

        public List<SpellSchool> SelectableSpellSchools
        {
            get
            {
                return _selectableSpellSchools;
            }
            set
            {
                _selectableSpellSchools = value;
            }
        }

        #endregion
        
        public SpellCardViewModel SpellCardViewModel
        {
            get
            {
                return _spellCardViewModel;
            }
            set
            {
                _spellCardViewModel = value;
                OnPropertyChanged();
            }
        }

        public string SpellName
        {
            get
            {
                return SpellCardViewModel.SpellName;
            }
            set
            {
                SpellCardViewModel.SpellName = value;
                OnPropertyChanged();
            }
        }

        public string SpellCasterClass
        {
            get
            {
                return SpellCardViewModel.CasterClass;
            }
            set
            {
                SpellCardViewModel.CasterClass = value;
                OnPropertyChanged();
            }
        }

        public int SpellLevel
        {
            get
            {
                return SpellCardViewModel.SpellLevel;
            }
            set
            {
                SpellCardViewModel.SpellLevel = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SpellSchool> SpellSchools
        {
            get
            {
                return SpellCardViewModel.SpellSchools;
            }
            set
            {
                SpellCardViewModel.SpellSchools = value;
                OnPropertyChanged();
            }
        }

        public SpellCardEditorViewModel(IDataService<SpellSchool> spellSchoolDataService)
        {
            _spellSchoolDataService = spellSchoolDataService;
            SpellCardViewModel = new SpellCardViewModel();

            InitSelectionCollections();
            
            OnPropertyChanged(nameof(SpellSchools));
        }

        private async Task InitSelectionCollections()
        {
            SelectableSpellSchools = (await _spellSchoolDataService.GetAll()).ToList();
        }

        public void AddOrRemoveSpellSchool([NotNull] SpellSchool spellSchool, bool addSpell)
        {
            if (addSpell == true && SpellSchools.All(x => x.Id != spellSchool.Id))
            {
                SpellSchools.Add(spellSchool);
            }
            else
            {
                SpellSchools.Remove(spellSchool);
            }

            OnPropertyChanged(nameof(SpellSchools));
        }
    }
}