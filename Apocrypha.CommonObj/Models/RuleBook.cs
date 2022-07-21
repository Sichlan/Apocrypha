using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.CommonObject.Models.Spells;

namespace Apocrypha.CommonObject.Models
{
    public class RuleBook : DatabaseObject
    {
        [Required]
        public Edition Edition { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        public DateTime? PublishedAt { get; set; }

        public string FallbackName { get; set; }
        [NotMapped]
        public string Name
        {
            get
            {
                return RuleBookTranslations[CultureInfo.CurrentCulture].Name ?? FallbackName;
            }
            set
            {
                RuleBookTranslations[CultureInfo.CurrentCulture].Name = value;
            }
        }
        
        public string FallbackDescription { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                return RuleBookTranslations[CultureInfo.CurrentCulture].Description ?? FallbackDescription;
            }
            set
            {
                RuleBookTranslations[CultureInfo.CurrentCulture].Description = value;
            }
        }

        public ICollection<SpellVariant> SpellVariants { get; set; }
        public TranslationCollection<RuleBookTranslation> RuleBookTranslations { get; set; }
    }
}