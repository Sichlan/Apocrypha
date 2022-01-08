using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellSubSchool : DatabaseObject
    {
        public ICollection<SpellVariant> SpellVariants { get; set; }
        public TranslationCollection<SpellSubSchoolTranslation> SpellSubSchoolTranslations { get; set; }

        [NotMapped]
        public string Name
        {
            get => SpellSubSchoolTranslations[CultureInfo.CurrentCulture].Name;
            set => SpellSubSchoolTranslations[CultureInfo.CurrentCulture].Name = value;
        }

        [NotMapped]
        public string Description
        {
            get => SpellSubSchoolTranslations[CultureInfo.CurrentCulture].Description;
            set => SpellSubSchoolTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }   
}