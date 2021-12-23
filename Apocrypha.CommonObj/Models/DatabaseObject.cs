using System.ComponentModel.DataAnnotations;

namespace Apocrypha.CommonObject.Models
{
    public class DatabaseObject
    {
        [Key]
        public int Id { get; set; }
    }
}