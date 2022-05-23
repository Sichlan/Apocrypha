using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellDescriptor : DatabaseObject
    {
        public ICollection<SpellVariant> SpellVariants { get; set; }
        public TranslationCollection<SpellDescriptorTranslation> SpellDescriptorTranslations { get; set; }

        public string NameFallback { get; set; }
        [NotMapped]
        public string Name
        {
            get => SpellDescriptorTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
            set => SpellDescriptorTranslations[CultureInfo.CurrentCulture].Name = value;
        }

        public string DescriptionFallback { get; set; }
        [NotMapped]
        public string Description
        {
            get => SpellDescriptorTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
            set => SpellDescriptorTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }
}