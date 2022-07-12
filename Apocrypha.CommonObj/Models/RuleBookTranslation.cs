using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class RuleBookTranslation : Translation<RuleBookTranslation>
    {
        public RuleBook RuleBook { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}