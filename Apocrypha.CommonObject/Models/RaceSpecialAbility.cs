using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class RaceSpecialAbility : DatabaseObject
{
    public Race Race { get; set; }
    public TranslationCollection<RaceSpecialAbilityTranslation> RaceSpecialAbilityTranslations { get; set; } = new();

    #region Translation

    public string FallbackName { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return RaceSpecialAbilityTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
        }
        set
        {
            RaceSpecialAbilityTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    public string FallbackDescription { get; set; }

    [NotMapped]
    public string Description
    {
        get
        {
            return RaceSpecialAbilityTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
        }
        set
        {
            RaceSpecialAbilityTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }

    #endregion
}