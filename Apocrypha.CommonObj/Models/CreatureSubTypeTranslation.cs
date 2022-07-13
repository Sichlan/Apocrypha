using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class CreatureSubTypeTranslation : Translation<CreatureSubTypeTranslation>
    {
        public CreatureSubType CreatureSubType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}