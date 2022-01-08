using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellSchool : DatabaseObject
    {
        public ICollection<SpellVariant> SpellVariants { get; set; }
        public TranslationCollection<SpellSchoolTranslation> SpellSchoolTranslations { get; set; }

        [NotMapped]
        public string Name
        {
            get => SpellSchoolTranslations[CultureInfo.CurrentCulture].Name;
            set => SpellSchoolTranslations[CultureInfo.CurrentCulture].Name = value;
        }

        [NotMapped]
        public string Description
        {
            get => SpellSchoolTranslations[CultureInfo.CurrentCulture].Description;
            set => SpellSchoolTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }
}