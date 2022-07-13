using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class RaceSpecialAbilityTranslation : Translation<RaceSpecialAbilityTranslation>
    {
        public RaceSpecialAbility RaceSpecialAbility {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
    }
}