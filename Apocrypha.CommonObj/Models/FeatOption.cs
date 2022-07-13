using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models
{
    // TODO: Expand this when Feats are added
    // TODO: Implement method to retrieve Feats based upon a FeatOption input
    /// <summary>
    /// Displays the option to take a feat and criteria for feats selectable with this option.<br/>
    /// <b>IMPORTANT:</b> This is neither a collection of feats nor has it a direct relation via foreign key or similar to feats. This class only displays criteria to filter the list of available feats!
    /// </summary>
    public class FeatOption : DatabaseObject
    {
        /// <summary>
        /// A concatted list of feat ids allowed to take when this option is presented.
        /// </summary>
        public string IdList { get; private set; }

        [NotMapped]
        public ICollection<int> FeatIds
        {
            get
            {
                return (IdList + "").Split(";")
                    .Where(x => int.TryParse(x, out var _))
                    .Select(x => int.Parse(x))
                    .ToList();
            }
            set
            {
                IdList = string.Join(';', value);
            }
        }
    }
}