using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Poisons;

public class Poison : DatabaseObject
{
    // View model stuff: CraftDC, Potency, MarketPrice
    public TranslationCollection<PoisonTranslation> PoisonTranslations { get; set; } = new();

    public string NameFallback { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return PoisonTranslations?[CultureInfo.CurrentCulture].Name ?? NameFallback;
        }
        set
        {
            PoisonTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    public string DescriptionFallback { get; set; }

    [NotMapped]
    public string Description
    {
        get
        {
            return PoisonTranslations?[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        }
        set
        {
            PoisonTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }

    public PoisonDeliveryMethod DeliveryMethod { get; set; }
    public int Toxicity { get; set; } = 10;
    public ICollection<PoisonPhase> Phases { get; set; }
}