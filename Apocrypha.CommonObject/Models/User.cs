using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Models.Poisons;

namespace Apocrypha.CommonObject.Models;

public class User : DatabaseObject
{
    public string Email { get; set; }
    public string Username { get; set; }
    public DateTime DateJoined { get; set; }
    public string PasswordHash { get; set; }
    public bool IsAdmin { get; set; }
    public ICollection<Character> Characters { get; set; }
    public ICollection<Poison> Poisons { get; set; }
}