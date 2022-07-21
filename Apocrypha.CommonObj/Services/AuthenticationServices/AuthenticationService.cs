using Apocrypha.CommonObject.Exceptions;
using Apocrypha.CommonObject.Models;
using Microsoft.AspNet.Identity;

namespace Apocrypha.CommonObject.Services.AuthenticationServices;

public class AuthenticationService : IAuthenticationService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserService _userService;

    public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher)
    {
        _userService = userService;
        _passwordHasher = passwordHasher;
    }

    public async Task<User> Login(string username, string password)
    {
        var storedUser = await _userService.GetByUsername(username);

        if (storedUser == null) throw new UserNotFoundException(username);

        var passwordVerificationResult =
            _passwordHasher.VerifyHashedPassword(storedUser.PasswordHash, password);

        if (passwordVerificationResult != PasswordVerificationResult.Success)
            throw new InvalidPasswordException(username, password);

        return storedUser;
    }

    public async Task<RegistrationResult> Register(string email, string username, string password,
        string confirmPassword)
    {
        var registrationResult = RegistrationResult.Success;

        try
        {
            if (password != confirmPassword) registrationResult = RegistrationResult.PasswordsDoNotMatch;

            var emailAccount = await _userService.GetByEmail(email);
            if (emailAccount != null) registrationResult = RegistrationResult.EmailAlreadyExists;

            var usernameAccount = await _userService.GetByUsername(username);
            if (usernameAccount != null) registrationResult = RegistrationResult.UsernameAlreadyExists;

            if (registrationResult == RegistrationResult.Success)
            {
                var hashedPassword = _passwordHasher.HashPassword(password);

                var user = new User
                {
                    Email = email, Username = username, PasswordHash = hashedPassword, DateJoined = DateTime.Now
                };

                _ = await _userService.Create(user);
            }
        }
        catch (Exception)
        {
            registrationResult = RegistrationResult.Failure;
        }

        return registrationResult;
    }
}