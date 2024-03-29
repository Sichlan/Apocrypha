﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class MovementMode : DatabaseObject
{
    public ICollection<RaceMovementMode> RaceMovementModes { get; set; }
    public TranslationCollection<MovementModeTranslation> MovementModeTranslations { get; set; } = new();

    #region Translation

    public string FallbackName { get; set; }

    [NotMapped]
    public string Name
    {
        get => MovementModeTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
        set => MovementModeTranslations[CultureInfo.CurrentCulture].Name = value;
    }

    public string FallbackDescription { get; set; }

    [NotMapped]
    public string Description
    {
        get => MovementModeTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
        set => MovementModeTranslations[CultureInfo.CurrentCulture].Description = value;
    }

    #endregion
}