using System.Collections.Generic;
using System.Linq;

namespace Apocrypha.WPF.ViewModels
{
    #region Mockup helper

    //TODO: Remove after mockup creation
    public enum SpellSchool
    {
        Abjuration,
        Conjuration,
        Divination,
        Enchantment,
        Evocation,
        Illusion,
        Necromancy,
        Transmutation,
        Universal
    }

    public enum SpellSubSchool
    {
        Calling,
        Creation,
        Healing,
        Summoning,
        Teleportation,
        Scrying,
        Charm,
        Compulsion,
        Figment,
        Glamer,
        Pattern,
        Phantasm,
        Shadow,
        Polymorph
    }

    public enum SpellDescriptor
    {
        Acid,
        Air,
        Chaotic,
        Cold,
        Darkness,
        Death,
        Earth,
        Electricity,
        Evil,
        Fear,
        Fire,
        Force,
        Good,
        LanguageDependent,
        Lawful,
        Light,
        MindAffecting,
        Sonic,
        Water
    }

    #endregion
    
    public class SpellCardViewModel : BaseViewModel
    {
        private string _spellName;
        private string _casterClass;
        private int _spellLevel;

        public string SpellName
        {
            get => _spellName;
            set
            {
                _spellName = value;
                OnPropertyChanged();
            }
        }

        public string CasterClass
        {
            get => _casterClass;
            set
            {
                _casterClass = value;
                OnPropertyChanged();
            }
        }

        public int SpellLevel
        {
            get => _spellLevel;
            set
            {
                _spellLevel = value;
                OnPropertyChanged();
            }
        }

        public SpellSchool SpellSchool { get; set; }
        public List<SpellSubSchool> SpellSubSchools { get; set; }
        public List<SpellDescriptor> SpellDescriptors { get; set; }

        public string SpellSubSchoolsString => string.Join(", ", SpellSubSchools.Select(x => x.ToString()));
        public string SpellDescriptorsString => string.Join(", ", SpellDescriptors.Select(x => x.ToString()));

        
        
        //TODO: Remove mockup constructor
        public SpellCardViewModel()
        {
            SpellName = "Test Spell";
            SpellSchool = SpellSchool.Abjuration;
            SpellSubSchools = new List<SpellSubSchool>() {SpellSubSchool.Calling, SpellSubSchool.Charm};
            SpellDescriptors = new List<SpellDescriptor>() {SpellDescriptor.Chaotic, SpellDescriptor.Evil, SpellDescriptor.MindAffecting};

            OnPropertyChanged(nameof(SpellSubSchoolsString));
            OnPropertyChanged(nameof(SpellDescriptorsString));
        }
    }
}