using System;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Services.DiceRollerServices;
using Moq;
using NUnit.Framework;

namespace Apocrypha.CommonObject.Tests.Services.DiceRollerServices
{
    [TestFixture]
    public class DiceRollerServiceTests
    {
        [SetUp]
        public void Setup()
        {
            _mockRandom = new Mock<Random>();
            _diceRollerService = new DiceRollerService(_mockRandom.Object);
            _mockRandom.Setup(s => s.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(5);
        }

        private IDiceRollerService _diceRollerService = null!;
        private Mock<Random> _mockRandom = null!;

        // [Test]
        // public async Task RollDice_TestEachValidOperatorAndOneInvalid()
        // {
        //     #region Arrange
        //     _mockRandom.Setup(s => s.Next(It.IsAny<int>(),It.IsAny<int>())).Returns(5);
        //     //   cleanup tests:
        //     var cleanup_Spaces = "1 1";
        //     var cleanup_encaseInCurlyBrackets = "3d2d1";
        //     
        //     //   separator tests:
        //     //     curly brackets:
        //     //       d:
        //     var separator_curlyBrackets_d_noDice = "{0,1,2}d1";
        //     var separator_curlyBrackets_d_justDice = "{2d5}d1";
        //     var separator_curlyBrackets_d_mixedDice = "{1d5,2}d1";
        //     //       dl:
        //     var separator_curlyBrackets_dl_noDice = "{0,1,2}dl1";
        //     var separator_curlyBrackets_dl_justDice = "{2d5}dl1";
        //     var separator_curlyBrackets_dl_mixedDice = "{1d5,2}dl1";
        //     //       dh:
        //     var separator_curlyBrackets_dh_noDice = "{0,1,2}dh1";
        //     var separator_curlyBrackets_dh_justDice = "{2d5}dh1";
        //     var separator_curlyBrackets_dh_mixedDice = "{1d5,2}dh1";
        //     //       k:
        //     var separator_curlyBrackets_k_noDice = "{0,1,2}k1";
        //     var separator_curlyBrackets_k_justDice = "{2d5}k1";
        //     var separator_curlyBrackets_k_mixedDice = "{1d5,2}k1";
        //     //       kl:
        //     var separator_curlyBrackets_kl_noDice = "{0,1,2}kl1";
        //     var separator_curlyBrackets_kl_justDice = "{2d5}kl1";
        //     var separator_curlyBrackets_kl_mixedDice = "{1d5,2}kl1";
        //     //       kh:
        //     var separator_curlyBrackets_kh_noDice = "{0,1,2}kh1";
        //     var separator_curlyBrackets_kh_justDice = "{2d5}kh1";
        //     var separator_curlyBrackets_kh_mixedDice = "{1d5,2}kh1";
        //     //       >:
        //     var separator_curlyBrackets_gt_noDice = "{0,1,2}>1";
        //     var separator_curlyBrackets_gt_justDice = "{2d5}>1";
        //     var separator_curlyBrackets_gt_mixedDice = "{1d5,2}>1";
        //     //       >=:
        //     var separator_curlyBrackets_gtoe_noDice = "{0,1,2}>=1";
        //     var separator_curlyBrackets_gtoe_justDice = "{2d5}>=1";
        //     var separator_curlyBrackets_gtoe_mixedDice = "{1d5,2}>=1";
        //     //       =:
        //     var separator_curlyBrackets_e_noDice = "{0,1,2}=1";
        //     var separator_curlyBrackets_e_justDice = "{2d5}=1";
        //     var separator_curlyBrackets_e_mixedDice = "{1d5,2}=1";
        //     //       <=:
        //     var separator_curlyBrackets_ltoe_noDice = "{0,1,2}<=1";
        //     var separator_curlyBrackets_ltoe_justDice = "{2d5}<=1";
        //     var separator_curlyBrackets_ltoe_mixedDice = "{1d5,2}<=1";
        //     //       <:
        //     var separator_curlyBrackets_lt_noDice = "{0,1,2}<1";
        //     var separator_curlyBrackets_lt_justDice = "{2d5}<1";
        //     var separator_curlyBrackets_lt_mixedDice = "{1d5,2}<1";
        //     //       <>:
        //     var separator_curlyBrackets_not_noDice = "{0,1,2}<>1";
        //     var separator_curlyBrackets_not_justDice = "{2d5}<>1";
        //     var separator_curlyBrackets_not_mixedDice = "{1d5,2}<>1";
        //     //     round brackets:
        //     var separator_roundBrackets_not_noDice = "2*(1+2+3)*4";
        //     
        //     //   function tests
        //     string floor = "floor(1.8)";
        //     string ceil = "ceil(1.8)";
        //     string round = "round(1.8)";
        //     string abs = "abs(-1.8)";
        //     string unusedBrackets = "(1.8)";
        //     
        //     //   operator tests
        //     //     dice:
        //     //       no reroll:
        //     var operator_dice_noReroll = "4d6";
        //
        //     #endregion
        //
        //     #region Act
        //
        //
        //
        //     #endregion
        //
        //     #region Assert
        //
        //
        //
        //     #endregion
        // }

        [Test]
        public async Task RollDice_TestOperators()
        {
            // Arrange
            var equation = "1-2*3.2/4%3+4d9";
            var exponent = "20^2";

            // Act
            var value = await _diceRollerService.RollDice(equation);
            var value2 = await _diceRollerService.RollDice(exponent);

            // Assert
            Assert.AreEqual(14.6, value[0][0]);
            Assert.AreEqual(400, value2[0][0]);
        }

        [Test]
        public async Task RollDice_TestFunctions()
        {
            // Arrange
            var floor = "floor(1.8)";
            var ceil = "ceil(1.8)";
            var round = "round(1.8)";
            var abs = "abs(-1.8)";

            // Act
            var floorResult = await _diceRollerService.RollDice(floor);
            var ceilResult = await _diceRollerService.RollDice(ceil);
            var roundResult = await _diceRollerService.RollDice(round);
            var absResult = await _diceRollerService.RollDice(abs);

            // Assert
            Assert.AreEqual(1, floorResult[0][0]);
            Assert.AreEqual(2, ceilResult[0][0]);
            Assert.AreEqual(2, roundResult[0][0]);
            Assert.AreEqual(1.8, absResult[0][0]);
        }

        [Test]
        public async Task RollDice_TestSeparators()
        {
            // Arrange
            const string parenthesis = "4*((15+1)/8)";
            const string curlyBrackets = "{0,1,2}dh1 + {12+4}dh1+ {4d6r!>2+4}dh1 +{4d6d1+4}dh1";

            // Act
            var parenthesisResult = await _diceRollerService.RollDice(parenthesis);
            var curlyBracketsResult = await _diceRollerService.RollDice(curlyBrackets);

            // Assert
            Assert.AreEqual(8, parenthesisResult[0][0]);
            Assert.AreEqual(20, curlyBracketsResult[0][0]);
        }

        [Test]
        public async Task RollDice_TestMultiTables()
        {
            // Arrange
            const string multiTable = "tc2r7[4d6d1]";

            // Act
            var multiTableResult = await _diceRollerService.RollDice(multiTable);
            TestContext.Out.WriteLine(multiTableResult);

            // Assert
            Assert.AreEqual(2, multiTableResult.Count);
            Assert.AreEqual(7, multiTableResult[0].Count);
            Assert.True(multiTableResult.SelectMany(x => x.Select(y => y)).All(x => x == 15));
        }
    }
}