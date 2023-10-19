using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class Alphabet : DatabaseObject
{
    public ICollection<Language> Languages { get; set; }
    public TranslationCollection<AlphabetTranslation> AlphabetTranslations { get; set; } = new();

    #region Translation

    public string FallbackName { get; set; }

    [NotMapped]
    public string Name
    {
        get => AlphabetTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
        set => AlphabetTranslations[CultureInfo.CurrentCulture].Name = value;
    }

    public string FallbackDescription { get; set; }

    [NotMapped]
    public string Description
    {
        get => AlphabetTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
        set => AlphabetTranslations[CultureInfo.CurrentCulture].Description = value;
    }

    #endregion
}