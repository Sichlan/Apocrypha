using System;
using System.Collections.Generic;
using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models
{
    public class Character : DatabaseObject
    {
        public User CreatorUser { get; set; }
        public Allignment TrueAllignment { get; set; }
        public int Budget { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        /// <summary>
        /// Disables some editing features to ensure no accidental edits during playtime.
        /// </summary>
        public bool DisableNonPlaytimeEditing { get; set; }
        public ICollection<CharacterItem> InventoryItems { get; set; }

        #region Profile

        public string CharacterName { get; set; }
        public string DisplayName { get; set; }

        #endregion
    }
}