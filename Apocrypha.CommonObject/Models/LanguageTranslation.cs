using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models;

public class LanguageTranslation : Translation<LanguageTranslation>
{
    public Language Language { get; set; }
}