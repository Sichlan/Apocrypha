using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells;

public class Spell : DatabaseObject
{
    public TranslationCollection<SpellTranslation> SpellTranslations { get; set; } = new();
    public ICollection<SpellVariant> SpellVariants { get; set; }

    public string NameFallback { get; set; }

    [NotMapped]
    public string Name
    {
        get => SpellTranslations[CultureInfo.CurrentCulture].Name ?? NameFallback;
        set => SpellTranslations[CultureInfo.CurrentCulture].Name = value;
    }
}