using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class MovementManeuverabilityTranslation : Translation<MovementManeuverabilityTranslation>
    {
        public MovementManeuverability MovementManeuverability { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}