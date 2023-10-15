namespace Apocrypha.CommonObject.Exceptions;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string Username { get; private set; }
    public string Password { get; private set; }
}