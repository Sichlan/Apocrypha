using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.CommonObject.Models.Poisons;

namespace Apocrypha.CommonObject.Models;

public class Condition : DatabaseObject
{
    public ICollection<PoisonPhaseElement> PoisonPhaseElements { get; set; }
    public TranslationCollection<ConditionTranslation> ConditionTranslations { get; set; } = new();

    public string NameFallback { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return ConditionTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        }
        set
        {
            ConditionTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    public string DescriptionFallback { get; set; }

    [NotMapped]
    public string Description
    {
        get
        {
            return ConditionTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        }
        set
        {
            ConditionTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }

    /// <summary>
    /// The difficulty class adjustment of this condition to add to a poison, if any. NULL indicates this condition can not be added to a poison.
    /// </summary>
    public int? PoisonCraftModifier { get; set; }

    /// <summary>
    /// True if this duration does not end naturally / needs a duration specified when crafted into a poison.
    /// </summary>
    public bool WithoutDuration { get; set; }
}