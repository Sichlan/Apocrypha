using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class Sense : DatabaseObject
{
    public ICollection<RaceSense> RaceSense { get; set; }
    public TranslationCollection<SenseTranslation> SenseTranslations { get; set; } = new();

    #region Translation

    public string FallbackName { get; set; }

    [NotMapped]
    public string Name
    {
        get => SenseTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
        set => SenseTranslations[CultureInfo.CurrentCulture].Name = value;
    }

    public string FallbackDescription { get; set; }

    [NotMapped]
    public string Description
    {
        get => SenseTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
        set => SenseTranslations[CultureInfo.CurrentCulture].Description = value;
    }

    #endregion
}