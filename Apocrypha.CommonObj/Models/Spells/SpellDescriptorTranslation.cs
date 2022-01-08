using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellDescriptorTranslation : Translation<SpellDescriptorTranslation>
    {
        public SpellDescriptor SpellDescriptor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}