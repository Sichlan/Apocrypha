using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models
{
    public class RaceBonusLanguage : DatabaseObject
    {
        public Race Race {get;set;}
        public Language Language {get;set;}
    }
}