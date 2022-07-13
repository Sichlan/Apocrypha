using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class RaceTranslation : Translation<RaceTranslation>
    {
        public Race Race { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}