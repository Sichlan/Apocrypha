﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class Allignment : DatabaseObject
{
    public string Abbreviation { get; set; }
    public TranslationCollection<AllignmentTranslation> AllignmentTranslations { get; set; } = new();

    public string NameFallback { get; set; }

    [NotMapped]
    public string Name
    {
        get => AllignmentTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        set => AllignmentTranslations[CultureInfo.CurrentCulture].Name = value;
    }

    public string DescriptionFallback { get; set; }

    [NotMapped]
    public string Description
    {
        get => AllignmentTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        set => AllignmentTranslations[CultureInfo.CurrentCulture].Description = value;
    }
}