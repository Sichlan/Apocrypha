using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class SenseTranslation : Translation<SenseTranslation>
    {
        public Sense Sense {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
    }
}