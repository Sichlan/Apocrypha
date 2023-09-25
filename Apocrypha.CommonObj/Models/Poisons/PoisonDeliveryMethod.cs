using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDeliveryMethod : DatabaseObject
{
    public TranslationCollection<PoisonDeliveryMethodTranslation> PoisonDeliveryMethodTranslations { get; set; } = new();
    public ICollection<Poison> Poisons { get; set; }

    public string NameFallback { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return PoisonDeliveryMethodTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        }
        set
        {
            PoisonDeliveryMethodTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    public string DescriptionFallback { get; set; }

    [NotMapped]
    public string Description
    {
        get
        {
            return PoisonDeliveryMethodTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        }
        set
        {
            PoisonDeliveryMethodTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }

    public int CraftDifficultyClassModifier { get; set; }
}