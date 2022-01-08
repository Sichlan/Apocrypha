using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellVariantTranslation : Translation<SpellVariantTranslation>
    {
        public SpellVariant SpellVariant { get; set; }
        public string Description { get; set; }
    }
}