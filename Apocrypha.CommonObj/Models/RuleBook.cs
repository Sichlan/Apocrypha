using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Spells;

namespace Apocrypha.CommonObject.Models
{
    public class RuleBook : DatabaseObject
    {
        [Required]
        public Edition Edition { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public DateTime? PublishedAt { get; set; }

        public ICollection<SpellVariant> SpellVariants { get; set; }
    }
}