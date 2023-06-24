using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class CreatureSizeCategory : DatabaseObject
{
    public int AttackAndArmorClassModifier { get; set; }
    public int SpecialAttackModifier { get; set; }
    public int HideModifier { get; set; }
    public double? HeightOrLengthMin { get; set; }
    public double? HeightOrLengthMax { get; set; }
    public double? WeightMin { get; set; }
    public double? WeightMax { get; set; }
    public double Space { get; set; }
    public int NaturalReachTall { get; set; }
    public int NaturalReachLong { get; set; }
    public TranslationCollection<CreatureSizeCategoryTranslation> CreatureSizeCategoryTranslations { get; set; }
    public ICollection<Race> Races { get; set; }

    #region Translation

    public string FallbackName { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return CreatureSizeCategoryTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
        }
        set
        {
            CreatureSizeCategoryTranslations[CultureInfo.CurrentCulture].Name = value;
        }
    }

    #endregion
}