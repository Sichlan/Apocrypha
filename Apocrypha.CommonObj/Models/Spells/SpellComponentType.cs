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

        [NotMapped]
        public string Name
        {
            get => SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Name;
            set => SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Name = value;
        }

        [NotMapped]
        public string Description
        {
            get => SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Description;
            set => SpellComponentTypeTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }
}