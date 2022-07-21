using System;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Exceptions;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services.AuthenticationServices;

namespace Apocrypha.WPF.State.Authenticators
{
    public interface IAuthenticator : IStateChanger
    {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }

        Task<RegistrationResult> Register(string email, string username, string password, string confirmnPassword);

        /// <summary>
        ///     Login to the application.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <exception cref="UserNotFoundException">Throwing when the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Throwing when the password is incorrect.</exception>
        /// <exception cref="Exception">Throwing when the login fails.</exception>
        Task Login(string username, string password);

        Task<bool> Logout();
    }
}