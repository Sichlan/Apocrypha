using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class Poison : DatabaseObject
{
    public string NameFallback { get; set; }
    public string DescriptionFallback { get; set; }
    public int Toxicity { get; set; } = 10;

    [ForeignKey(nameof(DeliveryMethod))] public int? DeliveryMethodId { get; set; }
    [ForeignKey(nameof(CreatorId))] public int? CreatorId { get; set; }

    [DeleteBehavior(DeleteBehavior.SetNull)]
    public PoisonDeliveryMethod DeliveryMethod { get; set; }

    [DeleteBehavior(DeleteBehavior.SetNull)]
    public User Creator { get; set; }

    public ICollection<PoisonPhase> Phases { get; set; }
    public TranslationCollection<PoisonTranslation> PoisonTranslations { get; set; } = new();


    [NotMapped]
    public string Name
    {
        get => PoisonTranslations?[CultureInfo.CurrentCulture].Name ?? NameFallback;
        set => PoisonTranslations[CultureInfo.CurrentCulture].Name = value;
    }

    [NotMapped]
    public string Description
    {
        get => PoisonTranslations?[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        set => PoisonTranslations[CultureInfo.CurrentCulture].Description = value;
    }
}