using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonSpecialEffect : DatabaseObject
{
    public string NameFallback { get; set; }
    public string DescriptionFallback { get; set; }
    public int CraftModifier { get; set; }

    public ICollection<PoisonPhaseElement> PoisonPhaseElements { get; set; }
    public TranslationCollection<PoisonSpecialEffectTranslation> PoisonSpecialEffectTranslations { get; set; } = new();

    [NotMapped]
    public string Name
    {
        get => PoisonSpecialEffectTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        set => PoisonSpecialEffectTranslations[CultureInfo.CurrentCulture].Name = value;
    }

    [NotMapped]
    public string Description
    {
        get => PoisonSpecialEffectTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        set => PoisonSpecialEffectTranslations[CultureInfo.CurrentCulture].Description = value;
    }
}