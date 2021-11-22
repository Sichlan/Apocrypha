using System;

namespace Apocrypha.CommonObject.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string username)
        {
            Username = username;
        }

        public UserNotFoundException(string username, string message) : base(message)
        {
            Username = username;
        }

        public UserNotFoundException(string username, string message, Exception innerException) : base(message,
            innerException)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}