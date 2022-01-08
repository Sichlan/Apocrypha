using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Spells
{
    public class SpellRangeTypeTranslation : Translation<SpellRangeTypeTranslation>
    {
        public SpellRangeType SpellRangeType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}