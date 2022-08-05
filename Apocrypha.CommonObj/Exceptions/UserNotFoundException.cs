namespace Apocrypha.CommonObject.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string username)
    {
        Username = username;
    }

    public string Username { get; set; }
}