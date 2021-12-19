using System.Collections.Generic;

namespace Apocrypha.CommonObject.Models
{
    public class Character : DatabaseObject
    {
        #region Profile

        public string CharacterName { get; set; }
        public string DisplayName { get; set; }

        #endregion
        public User CreatorUser { get; set; }
        public int Budget { get; set; }
        public IEnumerable<CharacterItem> InventoryItems { get; set; }
    }
}