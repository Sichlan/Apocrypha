using System;
using System.Collections.Generic;

namespace Apocrypha.CommonObject.Models
{
    public class User : DatabaseObject
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime DateJoined { get; set; }
        public string PasswordHash { get; set; }
        public IEnumerable<Character> Characters { get; set; }
    }
}