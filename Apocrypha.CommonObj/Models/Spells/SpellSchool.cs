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

        public string NameFallback { get; set; }
        [NotMapped]
        public string Name
        {
            get
            {
                return SpellSchoolTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
            }
            set
            {
                SpellSchoolTranslations[CultureInfo.CurrentCulture].Name = value;
            }
        }

        public string DescriptionFallback { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                return SpellSchoolTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
            }
            set
            {
                SpellSchoolTranslations[CultureInfo.CurrentCulture].Description = value;
            }
        }
    }
}