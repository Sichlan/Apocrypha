using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellVariant : DatabaseObject
    {
        public Spell Spell { get; set; }
        public TranslationCollection<SpellVariantTranslation> SpellVariantTranslations { get; set; }
        public RuleBook RuleBook { get; set; }
        public int? RuleBookPage { get; set; }
        public ICollection<SpellSchool> SpellSchools { get; set; }
        public ICollection<SpellSubSchool> SpellSubSchools { get; set; }
        public ICollection<SpellDescriptor> SpellDescriptors { get; set; }
        public ICollection<SpellComponent> SpellComponents { get; set; }
        public int CastingTimeValue { get; set; }
        
        
        [NotMapped]
        public string Description
        {
            get => SpellVariantTranslations[CultureInfo.CurrentCulture].Description;
            set => SpellVariantTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }
}