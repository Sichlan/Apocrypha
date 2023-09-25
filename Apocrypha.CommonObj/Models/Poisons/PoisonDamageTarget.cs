using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDamageTarget : DatabaseObject
{
    public ICollection<PoisonPhaseElement> PoisonPhaseElements { get; set; }
    public TranslationCollection<PoisonDamageTargetTranslation> PoisonDamageTargetTranslations { get; set; } = new();

    public string NameFallback { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return PoisonDamageTargetTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        }
        set
        {
            PoisonDamageTargetTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    public string DescriptionFallback { get; set; }

    [NotMapped]
    public string Description
    {
        get
        {
            return PoisonDamageTargetTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        }
        set
        {
            PoisonDamageTargetTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }

    public int CraftModifier { get; set; }
}