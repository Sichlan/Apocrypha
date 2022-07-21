using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class MovementManeuverability : DatabaseObject
{
    public ICollection<RaceMovementMode> RaceMovementModes { get; set; }
    public TranslationCollection<MovementManeuverabilityTranslation> MovementManeuverabilityTranslations { get; set; }

    #region Translation

    public string FallbackName { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return MovementManeuverabilityTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
        }
        set
        {
            MovementManeuverabilityTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    public string FallbackDescription { get; set; }

    [NotMapped]
    public string Description
    {
        get
        {
            return MovementManeuverabilityTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
        }
        set
        {
            MovementManeuverabilityTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }

    #endregion
}