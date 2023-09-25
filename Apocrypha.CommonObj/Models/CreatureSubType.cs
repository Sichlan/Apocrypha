using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class CreatureSubType : DatabaseObject
{
    public ICollection<Race> Races { get; set; }
    public TranslationCollection<CreatureSubTypeTranslation> CreatureSubTypeTranslations { get; set; } = new();

    #region Translation

    public string FallbackName { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return CreatureSubTypeTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
        }
        set
        {
            CreatureSubTypeTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    public string FallbackDescription { get; set; }

    [NotMapped]
    public string Description
    {
        get
        {
            return CreatureSubTypeTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
        }
        set
        {
            CreatureSubTypeTranslations[CultureInfo.CurrentCulture].Description = value;
        }
    }

    #endregion
}