using System.ComponentModel.DataAnnotations;

namespace Apocrypha.CommonObject.Models.Common;

public class DatabaseObject
{
    [Key] public int Id { get; set; }
}