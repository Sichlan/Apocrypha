using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    /// <summary>
    /// Notates the type of a spell component.
    /// Possible types are:
    /// - Verbal
    /// - Somatic
    /// - Material
    /// - Arcane Focus
    /// - Divine Focus
    /// - Experience
    /// - Other
    /// This list will NOT be expanded, unless explicitly necessary
    /// </summary>
    public class SpellComponentType : DatabaseObject
    {
        public ICollection<SpellComponent> SpellComponents { get; set; }
        public TranslationCollection<SpellComponentTypeTranslation> SpellComponentTypeTranslations { get; set; }

        public string NameFallback { get; set; }
        [NotMapped]
        public string Name
        {
            get
            {
                return SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
            }
            set
            {
                SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Name = value;
            }
        }

        public string DescriptionFallback { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                return SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
            }
            set
            {
                SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Description = value;
            }
        }

        public string AbbreviationFallback { get; set; }
        [NotMapped]
        public string Abbreviation
        {
            get
            {
                return SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Abbreviation ?? AbbreviationFallback;
            }
            set
            {
                SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Abbreviation = value;
            }
        }
    }
}