using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.CommonObject.Models.Spells;

namespace Apocrypha.CommonObject.Models
{
    public class ActionTimeIndicator : DatabaseObject
    {
        public TranslationCollection<ActionTimeIndicatorTranslation> ActionTimeIndicatorTranslations { get; set; }
        public ICollection<SpellVariant> SpellVariants { get; set; }
        

        public string NameFallback { get; set; }
        [NotMapped]
        public string Name
        {
            get
            {
                return ActionTimeIndicatorTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
            }
            set
            {
                ActionTimeIndicatorTranslations[CultureInfo.CurrentCulture].Name = value;
            }
        }

        public string DescriptionFallback { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                return ActionTimeIndicatorTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
            }
            set
            {
                ActionTimeIndicatorTranslations[CultureInfo.CurrentCulture].Description = value;
            }
        }
    }
}