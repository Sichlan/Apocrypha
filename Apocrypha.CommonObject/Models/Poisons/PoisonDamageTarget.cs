using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDamageTarget : DatabaseObject
{
    public string NameFallback { get; set; }
    public string DescriptionFallback { get; set; }
    public int CraftModifier { get; set; }

    public ICollection<PoisonPhaseElement> PoisonPhaseElements { get; set; }
    public TranslationCollection<PoisonDamageTargetTranslation> PoisonDamageTargetTranslations { get; set; } = new();


    [NotMapped]
    public string Name
    {
        get => PoisonDamageTargetTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        set => PoisonDamageTargetTranslations[CultureInfo.CurrentCulture].Name = value;
    }

    [NotMapped]
    public string Description
    {
        get => PoisonDamageTargetTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        set => PoisonDamageTargetTranslations[CultureInfo.CurrentCulture].Description = value;
    }
}