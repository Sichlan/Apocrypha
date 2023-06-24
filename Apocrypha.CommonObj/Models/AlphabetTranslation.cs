using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class AlphabetTranslation : Translation<AlphabetTranslation>
{
    public Alphabet Alphabet { get; set; }
}