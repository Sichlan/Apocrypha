using System.Collections.Generic;

namespace Apocrypha.CommonObject.Models
{
    public class Edition : DatabaseObject
    {
        public string Name { get; set; }
        public string System { get; set; }
        public bool Core { get; set; }
        public ICollection<RuleBook> RuleBooks { get; set; }
    }
}