using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public enum CreedAllignment
    {
        
    }
    public class Allignment : DatabaseObject
    {
        public string Abbreviation { get; set; }
        public TranslationCollection<AllignmentTranslation> Translations { get; set; }

        public string Name
        {
            get => Translations[CultureInfo.CurrentCulture].Name;
            set => Translations[CultureInfo.CurrentCulture].Name = value;
        }
    }
}