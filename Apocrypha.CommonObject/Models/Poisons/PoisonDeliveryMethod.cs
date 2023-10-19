using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDeliveryMethod : DatabaseObject
{
    public string NameFallback { get; set; }
    public string DescriptionFallback { get; set; }
    public int CraftDifficultyClassModifier { get; set; }

    public TranslationCollection<PoisonDeliveryMethodTranslation> PoisonDeliveryMethodTranslations { get; set; } = new();
    public ICollection<Poison> Poisons { get; set; }


    [NotMapped]
    public string Name
    {
        get => PoisonDeliveryMethodTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        set => PoisonDeliveryMethodTranslations[CultureInfo.CurrentCulture].Name = value;
    }


    [NotMapped]
    public string Description
    {
        get => PoisonDeliveryMethodTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        set => PoisonDeliveryMethodTranslations[CultureInfo.CurrentCulture].Description = value;
    }
}