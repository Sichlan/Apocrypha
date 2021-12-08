using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.CommonObject.Services.AuthenticationServices;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace Apocrypha.CommonObject.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IUserService> _mockUserService;
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private AuthenticationService _authenticationService;
        
        [SetUp]
        public void Setup()
        {
            _mockUserService = new Mock<IUserService>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _authenticationService = new AuthenticationService(_mockUserService.Object, _mockPasswordHasher.Object);
        }
        
        [Test]
        public async Task Login_WithCorrectPasswordForExistingUser_ReturnsAccountForCorrectUsername()
        {
            // Arrange
            var expectedUsername = "TestUser";
            var password = "TestPassword";

            _mockUserService.Setup(s => s.GetByUsername(expectedUsername))
                .ReturnsAsync(new User() {Username = expectedUsername});
            _mockPasswordHasher.Setup(s => s.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Success);

            // Act
            var user = await _authenticationService.Login(expectedUsername, password);

            // Assert
            var actualUsername = user.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }
    }
}