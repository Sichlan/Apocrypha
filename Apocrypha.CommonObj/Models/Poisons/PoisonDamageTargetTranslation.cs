using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonDamageTargetTranslation : Translation<PoisonDamageTargetTranslation>
{
    public PoisonDamageTarget PoisonDamageTarget { get; set; }
}