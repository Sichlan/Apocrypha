using Apocrypha.CommonObject.Exceptions;
using Apocrypha.CommonObject.Models;

namespace Apocrypha.CommonObject.Services.AuthenticationServices;

public enum RegistrationResult
{
    Success,
    PasswordsDoNotMatch,
    EmailAlreadyExists,
    UsernameAlreadyExists,
    Failure
}

public interface IAuthenticationService
{
    Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);


    /// <summary>
    ///     Login to the application.
    /// </summary>
    /// <param name="username">The user's name.</param>
    /// <param name="password">The user's password.</param>
    /// <returns>The account for the user</returns>
    /// <exception cref="UserNotFoundException">Throwing if the user does not exist.</exception>
    /// <exception cref="InvalidPasswordException">Throwing if the password is incorrect.</exception>
    /// <exception cref="Exception">Throwing if the login fails.</exception>
    Task<User> Login(string username, string password);
}