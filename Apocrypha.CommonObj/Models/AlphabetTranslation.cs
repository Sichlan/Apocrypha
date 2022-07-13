using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class AlphabetTranslation : Translation<AlphabetTranslation>
    {
        public Alphabet Alphabet { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}