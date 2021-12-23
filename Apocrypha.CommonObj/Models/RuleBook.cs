using System.ComponentModel.DataAnnotations;

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
        public System.DateTime? PublishedAt { get; set; }
    }
}