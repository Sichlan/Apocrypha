﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells;

public class SpellRangeType : DatabaseObject
{
    public ICollection<SpellVariant> SpellVariants { get; set; }
    public TranslationCollection<SpellRangeTypeTranslation> SpellRangeTypeTranslations { get; set; } = new();

    public string NameFallback { get; set; }

    [NotMapped]
    public string Name
    {
        get => SpellRangeTypeTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        set => SpellRangeTypeTranslations[CultureInfo.CurrentCulture].Name = value;
    }

    public string DescriptionFallback { get; set; }

    [NotMapped]
    public string Description
    {
        get => SpellRangeTypeTranslations[CultureInfo.CurrentCulture].Description ?? DescriptionFallback;
        set => SpellRangeTypeTranslations[CultureInfo.CurrentCulture].Description = value;
    }
}