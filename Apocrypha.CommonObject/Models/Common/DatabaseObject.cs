using System.ComponentModel.DataAnnotations;

namespace Apocrypha.CommonObject.Models.Common;

public class DatabaseObject
{
    /// <summary>
    /// The primary key for this database object.
    /// </summary>
    [Key]
    public int Id { get; set; }
}