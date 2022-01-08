using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class Allignment : DatabaseObject
    {
        public string Abbreviation { get; set; }
        public TranslationCollection<AllignmentTranslation> Translations { get; set; }

        [NotMapped]
        public string Name
        {
            get => Translations[CultureInfo.CurrentCulture].Name;
            set => Translations[CultureInfo.CurrentCulture].Name = value;
        }

        [NotMapped]
        public string Description
        {
            get => Translations[CultureInfo.CurrentCulture].Description;
            set => Translations[CultureInfo.CurrentCulture].Description = value;
        }
    }
}