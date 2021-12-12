using Apocrypha.CommonObject.Models;
using Apocrypha.EntityFramework.Services.Common;
using Moq;
using NUnit.Framework;

namespace Apocrypha.EntityFramework.Tests.Services
{
    [TestFixture]
    public class UserDataServiceTests
    {
        private Mock<ApocryphaDbContextFactory> _contextFactory;
        private Mock<NonQueryDataService<User>> _nonQueryDataService;
        
        [SetUp]
        public void Setup()
        {
            _contextFactory = new Mock<ApocryphaDbContextFactory>();
            _nonQueryDataService = new Mock<NonQueryDataService<User>>();
        }
    }
}