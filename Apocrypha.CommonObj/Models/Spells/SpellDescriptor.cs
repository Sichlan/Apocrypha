using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellDescriptor : DatabaseObject
    {
        public SpellVariant SpellVariant { get; set; }
        public TranslationCollection<SpellDescriptorTranslation> SpellDescriptorTranslations { get; set; }

        [NotMapped]
        public string Name
        {
            get => SpellDescriptorTranslations[CultureInfo.CurrentCulture].Name;
            set => SpellDescriptorTranslations[CultureInfo.CurrentCulture].Name = value;
        }

        [NotMapped]
        public string Description
        {
            get => SpellDescriptorTranslations[CultureInfo.CurrentCulture].Description;
            set => SpellDescriptorTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }
}