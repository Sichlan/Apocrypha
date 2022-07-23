using Apocrypha.CommonObject.Exceptions;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.CommonObject.Services.AuthenticationServices;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace Apocrypha.CommonObject.Tests.Services.AuthenticationServices;

[TestFixture]
public class AuthenticationServiceTests
{
    [SetUp]
    public void Setup()
    {
        _mockUserService = new Mock<IUserService>();
        _mockPasswordHasher = new Mock<IPasswordHasher>();
        _authenticationService = new AuthenticationService(_mockUserService.Object, _mockPasswordHasher.Object);
    }

    private Mock<IUserService> _mockUserService;
    private Mock<IPasswordHasher> _mockPasswordHasher;
    private AuthenticationService _authenticationService;

    [Test]
    public async Task Login_WithCorrectPasswordForExistingUser_ReturnsAccountForCorrectUsername()
    {
        // Arrange
        const string expectedUsername = "TestUser";
        const string password = "TestPassword";

        _mockUserService.Setup(s => s.GetByUsername(expectedUsername))
            .ReturnsAsync(new User
                {Username = expectedUsername});
        _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
            .Returns(PasswordVerificationResult.Success);

        // Act
        var user = await _authenticationService.Login(expectedUsername, password);

        // Assert
        var actualUsername = user.Username;
        Assert.AreEqual(expectedUsername, actualUsername);
    }

    [Test]
    public void Login_WithIncorrectPasswordForExistingUser_ThrowsInvalidPasswordExceptionForUsername()
    {
        // Arrange
        const string expectedUsername = "TestUser";
        const string password = "TestPassword";

        _mockUserService.Setup(s => s.GetByUsername(expectedUsername))
            .ReturnsAsync(new User
                {Username = expectedUsername});
        _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
            .Returns(PasswordVerificationResult.Failed);

        // Act
        var invalidPasswordException =
            Assert.ThrowsAsync<InvalidPasswordException>(async () =>
                await _authenticationService.Login(expectedUsername, password));

        // Assert
        var actualUsername = invalidPasswordException?.Username;
        Assert.AreEqual(expectedUsername, actualUsername);
    }

    [Test]
    public void Login_WithNonExistingUsername_ThrowsUserNotFoundException()
    {
        // Arrange
        const string expectedUsername = "TestUser";
        const string password = "TestPassword";

        _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
            .Returns(PasswordVerificationResult.Failed);

        // Act
        var userNotFoundException =
            Assert.ThrowsAsync<UserNotFoundException>(async () =>
                await _authenticationService.Login(expectedUsername, password));

        // Assert
        var actualUsername = userNotFoundException?.Username;
        Assert.AreEqual(expectedUsername, actualUsername);
    }

    [Test]
    public async Task Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch()
    {
        // Arrange
        const string password = "1234";
        const string confirmPassword = "4321";
        const RegistrationResult expectedResult = RegistrationResult.PasswordsDoNotMatch;

        // Act
        var actualResult = await _authenticationService.Register(It.IsAny<string>(),
            It.IsAny<string>(), password, confirmPassword);

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Register_WithEmailAlreadyExists_ReturnsEmailAlreadyExists()
    {
        // Arrange
        const string email = "test@testmail.com";
        const RegistrationResult expectedResult = RegistrationResult.EmailAlreadyExists;
        _mockUserService.Setup(s => s.GetByEmail(email)).ReturnsAsync(() => new User());

        // Act
        var actualResult = await _authenticationService.Register(email, It.IsAny<string>(),
            It.IsAny<string>(), It.IsAny<string>());

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Register_WithUsernameAlreadyExists_ReturnsUsernameAlreadyExists()
    {
        // Arrange
        const string username = "testUser";
        const RegistrationResult expectedResult = RegistrationResult.UsernameAlreadyExists;
        _mockUserService.Setup(s => s.GetByUsername(username)).ReturnsAsync(() => new User());

        // Act
        var actualResult = await _authenticationService.Register(It.IsAny<string>(), username,
            It.IsAny<string>(), It.IsAny<string>());

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Register_WithCorrectData_ReturnsSuccess()
    {
        // Arrange
        const RegistrationResult expectedResult = RegistrationResult.Success;

        // Act
        var actualResult = await _authenticationService.Register(It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>());

        // Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Register_ProvokeException_ReturnsFailure()
    {
        // Arrange
        const RegistrationResult expectedResult = RegistrationResult.Failure;
        _mockUserService.Setup(s => s.GetByEmail(It.IsAny<string>()))
            .Throws<Exception>();

        // Act
        var actualResult = await _authenticationService.Register(It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>());

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}