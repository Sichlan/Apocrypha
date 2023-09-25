using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonSpecialEffect : DatabaseObject
{
    public ICollection<PoisonPhaseElement> PoisonPhaseElements { get; set; }
    public TranslationCollection<PoisonSpecialEffectTranslation> PoisonSpecialEffectTranslations { get; set; } = new();

    public string NameFallback { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return PoisonSpecialEffectTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        }
        set
        {
            PoisonSpecialEffectTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    public string DescriptionFallback { get; set; }

    [NotMapped]
    public string Description
    {
        get
        {
            return PoisonSpecialEffectTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        }
        set
        {
            PoisonSpecialEffectTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }

    public int CraftModifier { get; set; }
}