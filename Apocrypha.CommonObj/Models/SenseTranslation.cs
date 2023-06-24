using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class SenseTranslation : Translation<SenseTranslation>
{
    public Sense Sense { get; set; }
}