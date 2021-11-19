using System.Collections;
using System.Collections.Generic;

namespace Apocrypha.CommonObject.Models
{
    public class Character : DatabaseObject
    {
        public User CreatorUser { get; set; }
        public int Budget { get; set; }
        public IEnumerable<CharacterItem> InventoryItems { get; set; }
    }
}