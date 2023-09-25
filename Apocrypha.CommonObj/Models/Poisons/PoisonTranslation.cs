using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonTranslation : Translation<PoisonTranslation>
{
    public Poison Poison { get; set; }
}