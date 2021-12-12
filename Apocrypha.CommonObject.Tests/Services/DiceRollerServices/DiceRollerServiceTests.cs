using System;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Services.DiceRollerServices;
using Moq;
using NUnit.Framework;

namespace Apocrypha.CommonObject.Tests.Services.DiceRollerServices
{
    [TestFixture]
    public class DiceRollerServiceTests
    {
        private IDiceRollerService _diceRollerService;
        private Mock<Random> _mockRandom;

        [SetUp]
        public void Setup()
        {
            _mockRandom = new Mock<Random>();
            _diceRollerService = new DiceRollerService(_mockRandom.Object);
            
            _mockRandom.Setup(s => s.Next(It.IsAny<int>(),It.IsAny<int>())).Returns(5);
        }

        [Test]
        public async Task RollDice_TestOperators()
        {
            // Arrange
            string equation = "1-2*3.2/4%3+4d9";
            string exponent = "20^2";
            
            // Act
            var value = await _diceRollerService.RollDice(equation);
            var value2 = await _diceRollerService.RollDice(exponent);

            // Assert
            Assert.AreEqual(14.6, value);
            Assert.AreEqual(400, value2);
        }

        [Test]
        public async Task RollDice_TestFunctions()
        {
            // Arrange
            string floor = "floor(1.8)";
            string ceil = "ceil(1.8)";
            string round = "round(1.8)";
            string abs = "abs(-1.8)";
            
            // Act
            var floorResult = await _diceRollerService.RollDice(floor);
            var ceilResult = await _diceRollerService.RollDice(ceil);
            var roundResult = await _diceRollerService.RollDice(round);
            var absResult = await _diceRollerService.RollDice(abs);
            
            // Assert
            Assert.AreEqual(1, floorResult);
            Assert.AreEqual(2, ceilResult);
            Assert.AreEqual(2, roundResult);
            Assert.AreEqual(1.8, absResult);
        }

        [Test]
        public async Task RollDice_TestSeparators()
        {
            // Arrange
            string parenthesis = "4*((15+1)/8)";
            string curlyBrackest = "{0,1,2}dh1 + {12+4}dh1+ {4d6r!>2+4}dh1 +{4d6d1+4}dh1";

            // Act
            var parenthesisResult = await _diceRollerService.RollDice(parenthesis);
            var curlyBracketsResult = await _diceRollerService.RollDice(curlyBrackest);

            // Assert
            Assert.AreEqual(8, parenthesisResult);
            Assert.AreEqual(20, curlyBracketsResult);
        }
    }
}