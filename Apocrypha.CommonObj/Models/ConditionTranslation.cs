using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class ConditionTranslation : Translation<ConditionTranslation>
{
    public Condition Condition { get; set; }
}