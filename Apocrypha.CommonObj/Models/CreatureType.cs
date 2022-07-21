using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.CommonObject.Models
{
    public class CreatureType : DatabaseObject
    {
        
        public ICollection<Race> Races { get; set; }
        public TranslationCollection<CreatureTypeTranslation> CreatureTypeTranslations { get; set; } 

        #region Translation

        public string FallbackName { get; set; }
        [NotMapped]
        public string Name
        {
            get
            {
                return CreatureTypeTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
            }
            set
            {
                CreatureTypeTranslations[CultureInfo.CurrentCulture].Name = value;
            }
        }
        
        public string FallbackDescription { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                return CreatureTypeTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
            }
            set
            {
                CreatureTypeTranslations[CultureInfo.CurrentCulture].Description = value;
            }
        }

        #endregion
    }
}