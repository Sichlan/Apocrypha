﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class Race : DatabaseObject
{
    public RuleBook RuleBook { get; set; }
    public int? RuleBookPage { get; set; }
    public CreatureType CreatureType { get; set; }
    public CreatureSubType CreatureSubType { get; set; }
    public CreatureSizeCategory CreatureSizeCategory { get; set; }
    public int StrengthBonus { get; set; }
    public int DexterityBonus { get; set; }
    public int ConstitutionBonus { get; set; }
    public int IntelligenceBonus { get; set; }
    public int WisdomBonus { get; set; }
    public int CharismaBonus { get; set; }
    public ICollection<RaceMovementMode> RaceMovementModes { get; set; }
    public ICollection<RaceSense> RaceSenses { get; set; }
    public ICollection<RaceAdditionalLanguage> AutomaticLanguages { get; set; }
    public ICollection<RaceBonusLanguage> BonusLanguages { get; set; }
    public int AdditionalSkillPoints { get; set; }
    public ICollection<RaceFeatOption> AdditionalFeatOptions { get; set; }
    public ICollection<RaceSpecialAbility> SpecialAbilities { get; set; }
    public int? LevelAdjustment { get; set; }
    public int ChallengeRating { get; set; }
    public TranslationCollection<RaceTranslation> Translations { get; set; } = new();


    #region Translation

    public string FallbackName { get; set; }

    [NotMapped]
    public string Name
    {
        get => Translations[CultureInfo.CurrentCulture].Name ?? FallbackName;
        set => Translations[CultureInfo.CurrentCulture].Name = value;
    }

    public string FallbackDescription { get; set; }

    [NotMapped]
    public string Description
    {
        get => Translations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
        set => Translations[CultureInfo.CurrentCulture].Description = value;
    }

    #endregion
}