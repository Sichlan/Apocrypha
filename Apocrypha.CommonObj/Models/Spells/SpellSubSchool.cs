using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells;

public class SpellSubSchool : DatabaseObject
{
    public ICollection<SpellVariant> SpellVariants { get; set; }
    public TranslationCollection<SpellSubSchoolTranslation> SpellSubSchoolTranslations { get; set; }

    public string NameFallback { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return SpellSubSchoolTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        }
        set
        {
            SpellSubSchoolTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    public string DescriptionFallback { get; set; }

    [NotMapped]
    public string Description
    {
        get
        {
            return SpellSubSchoolTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        }
        set
        {
            SpellSubSchoolTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }
}