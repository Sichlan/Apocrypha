using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells;

public class SpellTranslation : Translation<SpellTranslation>
{
    public Spell Spell { get; set; }
}