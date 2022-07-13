using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models
{
    public class RaceAdditionalLanguage : DatabaseObject
    {
        public Race Race {get;set;}
        public Language Language {get;set;}
    }
}