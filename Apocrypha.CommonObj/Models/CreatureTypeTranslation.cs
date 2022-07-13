using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class CreatureTypeTranslation : Translation<CreatureTypeTranslation>
    {
        public CreatureType CreatureType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}