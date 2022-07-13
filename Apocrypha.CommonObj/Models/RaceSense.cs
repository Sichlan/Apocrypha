using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models
{
    public class RaceSense : DatabaseObject
    {
        public Race Race {get;set;}
        public Sense Sense {get;set;}
        public int Distance {get;set;}
    }
}