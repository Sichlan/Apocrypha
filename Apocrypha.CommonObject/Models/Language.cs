﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class Language : DatabaseObject
{
    public Alphabet Alphabet { get; set; }
    public TranslationCollection<LanguageTranslation> LanguageTranslations { get; set; } = new();

    #region Translation

    public string FallbackName { get; set; }

    [NotMapped]
    public string Name
    {
        get => LanguageTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
        set => LanguageTranslations[CultureInfo.CurrentCulture].Name = value;
    }

    public string FallbackDescription { get; set; }

    [NotMapped]
    public string Description
    {
        get => LanguageTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
        set => LanguageTranslations[CultureInfo.CurrentCulture].Description = value;
    }

    #endregion
}