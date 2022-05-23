using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class ActionTimeIndicatorTranslation : Translation<ActionTimeIndicatorTranslation>
    {
        public ActionTimeIndicator ActionTimeIndicator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}