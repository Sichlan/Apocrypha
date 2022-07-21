using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models
{
    public class RaceMovementMode : DatabaseObject
    {
        public Race Race {get;set;}
        public MovementMode MovementMode {get;set;}
        public MovementManeuverability MovementManeuverability {get;set;}
        public int Distance {get;set;}
    }
}