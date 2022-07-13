using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class MovementModeTranslation : Translation<MovementModeTranslation>
    {
        public MovementMode MovementMode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}