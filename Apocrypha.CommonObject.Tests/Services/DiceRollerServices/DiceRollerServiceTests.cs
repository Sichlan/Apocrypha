using Apocrypha.CommonObject.Exceptions;
using Apocrypha.CommonObject.Services.DiceRollerServices;
using Moq;
using NUnit.Framework;

namespace Apocrypha.CommonObject.Tests.Services.DiceRollerServices;

[TestFixture]
public class DiceRollerServiceTests
{
    [SetUp]
    public void Setup()
    {
        _mockRandom = new Mock<Random>();
        _mockRandom.Setup(s => s.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(5);

        _diceRollerService = new DiceRollerService(_mockRandom.Object);
    }

    private IDiceRollerService _diceRollerService = null!;
    private Mock<Random> _mockRandom = null!;

    // Modifier
    [TestCase("1+1", ExpectedResult = 2)]
    [TestCase("1-1", ExpectedResult = 0)]
    [TestCase("2*3", ExpectedResult = 6)]
    [TestCase("25/5", ExpectedResult = 5)]
    [TestCase("9%7", ExpectedResult = 2)]
    [TestCase("3^4", ExpectedResult = 81)]
    [TestCase("3d7", ExpectedResult = 15)]
    // Functions
    [TestCase("floor(1.8)", ExpectedResult = 1)]
    [TestCase("ceil(1.8)", ExpectedResult = 2)]
    [TestCase("round(1.8)", ExpectedResult = 2)]
    [TestCase("round(1.4)", ExpectedResult = 1)]
    [TestCase("abs(-1.8)", ExpectedResult = 1.8)]
    [TestCase("abs(2.8)", ExpectedResult = 2.8)]
    // Additional expressions
    [TestCase("3*2+4*5", ExpectedResult = 26)]
    public async Task<double> RollDice_TestOperators(string expression)
    {
        // Arrange
        var equation = expression;

        // Act
        var value = await _diceRollerService.RollDice(equation);

        // Assert
        return value[0][0];
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
        Assert.That(multiTableResult.Count, Is.EqualTo(2));
        Assert.That(multiTableResult[0].Count, Is.EqualTo(7));
        Assert.That(multiTableResult.SelectMany(x => x.Select(y => y)).All(x => x == 15), Is.True);
    }

    [Test]
    public void RollDice_IncorrectEquation_ThrowsUnsolvableException()
    {
        // Arrange
        const string equation = "incorrectInput";

        // Act
        var unsolvableEquationException = Assert.ThrowsAsync<UnsolvableEquationException>(async () =>
            await _diceRollerService.RollDice(equation));

        // Assert
        Assert.That(unsolvableEquationException?.Equation, Is.EqualTo(equation));
    }

    [Test]
    public async Task RollDice_GenerateTableWithMissingColumnOrRow_ReturnsTables()
    {
        // Arrange
        const string oneColumnTableEquation = "tr3[3]";
        const string oneRowTableEquation = "tc3[3]";

        var expectedOneColumnTable = new List<List<double>>
        {
            new() {3, 3, 3}
        };
        var expectedOneRowTable = new List<List<double>>
        {
            new() {3},
            new() {3},
            new() {3},
        };

        // Act
        var actualColumnTableEquation = await _diceRollerService.RollDice(oneColumnTableEquation);
        var actualRowTableEquation = await _diceRollerService.RollDice(oneRowTableEquation);

        // Assert
        Assert.That(actualColumnTableEquation, Is.EquivalentTo(expectedOneColumnTable));
        Assert.That(actualRowTableEquation, Is.EquivalentTo(expectedOneRowTable));
    }

    [Test]
    public void RollDice_EquateDivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        const string divideByZeroEquation = "1/0";

        // Act
        var divideByZeroException = Assert.ThrowsAsync<DivideByZeroException>(async () => await _diceRollerService.RollDice(divideByZeroEquation));

        // Assert
        Assert.That(divideByZeroException != null, Is.True);
    }

    [Test]
    public async Task RollDice_ReRollExplicit_RESULT()
    {
        // Arrange
        const string reRollLessThatThreeEquation = "100d4r!<4";

        // Act
        var result = await new DiceRollerService(new Random()).RollDice(reRollLessThatThreeEquation);

        // Assert
        Assert.That(result[0][0], Is.EqualTo(400d));
    }
}