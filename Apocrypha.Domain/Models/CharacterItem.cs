using System;

namespace Apocrypha.CommonObject.Models
{
    public class CharacterItem : DatabaseObject
    {
        public Item Item { get; set; }
        public Character Owner { get; set; }
        public int Quantity { get; set; }
        public DateTime AquiredAt { get; set; }
    }
}