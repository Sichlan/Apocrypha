using System.Globalization;
using System.Text.RegularExpressions;
using Apocrypha.CommonObject.Exceptions;

namespace Apocrypha.CommonObject.Services.DiceRollerServices;

internal enum RollOperator
{
    Exponent,
    Modulo,
    Division,
    Multiplication,
    Subtraction,
    Addition
}

internal enum RollFunction
{
    Floor,
    Ceiling,
    Round,
    Absolute
}

public class DiceRollerService : IDiceRollerService
{
    private readonly Random _random;

    public DiceRollerService(Random random)
    {
        _random = random;
    }

#pragma warning disable 1998

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<List<List<double>>> RollDice(string equation)
    {
        var output = new List<List<double>>();

        var match = Regex.Match(equation, @"^t(c([0-9]+))?(r([0-9]+))?\[((?>\[(?<c>)|[^\[\]]+|\](?<-c>))*(?(c)(?!)))\]$");

        if (Regex.IsMatch(equation, @"^t(c([0-9]+))?(r([0-9]+))?\[((?>\[(?<c>)|[^\[\]]+|\](?<-c>))*(?(c)(?!)))\]$"))
        {
            if (!int.TryParse(match.Groups[2].Value, out var columns))
                columns = 1;
            if (!int.TryParse(match.Groups[4].Value, out var rows))
                rows = 1;

            for (var i = 0; i < columns; i++)
            {
                output.Add(new List<double>());
                for (var j = 0; j < rows; j++)
                    output[i].Add(Equate(match.Groups[5].Value));
            }
        }
        else
        {
            output.Add(new List<double>());
            output[0].Add(Equate(equation));
        }

        return output;
    }
#pragma warning restore 1998

    private double Equate(string equation)
    {
        #region Cleanup

        var currentExpression = equation.Replace(" ", "");
        currentExpression = Regex.Replace(currentExpression, @"([0-9]+d[0-9]+)((d|dh|dl|k|kh|kl|>|>=|=|<=|<|<>)[0-9]+)",
            m => EncaseInCurlyBrackets(m));

        #endregion

        #region Separators

        // Curly brackets with modifiers - separator { }x
        currentExpression = Regex.Replace(currentExpression,
            @"\{((?>\{(?<c>)|([^{},]+)|,|\}(?<-c>))*(?(c)(?!)))\}((d|dl|dh|k|kl|kh|>|>=|=|<=|<|<>)([0-9]+))?",
            m => EquateCurlyBrackets(m));
        // Parenthesis - separator ( )
        currentExpression = Regex.Replace(currentExpression, @"\(((?>\((?<c>)|[^()]+|\)(?<-c>))*(?(c)(?!)))\)", m => EquateSeparatorParenthesis(m));

        #endregion

        #region Functions

        var functionRegex = @"FUNCTION\((\-?[0-9]{1,}(\.[0-9]{1,})?)\)";

        //Floor - function floor(x)
        currentExpression = Regex.Replace(currentExpression, functionRegex.Replace("FUNCTION", "floor"), m => EquateFunction(m, RollFunction.Floor));
        //Ceiling - function ceil(x)
        currentExpression = Regex.Replace(currentExpression, functionRegex.Replace("FUNCTION", "ceil"), m => EquateFunction(m, RollFunction.Ceiling));
        //Round - function round(x)
        currentExpression = Regex.Replace(currentExpression, functionRegex.Replace("FUNCTION", "round"), m => EquateFunction(m, RollFunction.Round));
        //Absolute - function abs(x)
        currentExpression = Regex.Replace(currentExpression, functionRegex.Replace("FUNCTION", "abs"), m => EquateFunction(m, RollFunction.Absolute));

        // remove brackets around single numbers
        // e. g. (20.9) => 20.9, (20+9) stays unchanged
        const string bracketPairRegex = @"\((\-?[0-9]{1,}(\.[0-9]{1,})?)\)";
        while (Regex.IsMatch(currentExpression, bracketPairRegex))
            currentExpression = Regex.Replace(currentExpression, bracketPairRegex, m => m.Groups[1].ToString());

        #endregion

        #region Operators

        const string diceRegex = @"([0-9]{1,})d([0-9]{1,})(r(!)?(>|>=|=|<=|<|<>)([0-9]))?";
        while (Regex.IsMatch(currentExpression, diceRegex))
            // Dice - operator d
            currentExpression = Regex.Replace(currentExpression, diceRegex, m => SumDice(m));

        const string nonDoubleOperatorRegex = @"(\-?[0-9]{1,})\OPERATOR(\-?[0-9]{1,})";

        while (Regex.IsMatch(currentExpression, nonDoubleOperatorRegex.Replace(@"\OPERATOR", @"[%^]")))
        {
            // Exponent - operator ^
            currentExpression = Regex.Replace(currentExpression, nonDoubleOperatorRegex.Replace("OPERATOR", "^"),
                m => EquateNonDoubleOperator(m, RollOperator.Exponent));
            // Modulo - operator %
            currentExpression = Regex.Replace(currentExpression, nonDoubleOperatorRegex.Replace("OPERATOR", "%"),
                m => EquateNonDoubleOperator(m, RollOperator.Modulo));
        }

        const string doubleOperatorRegex = @"(\-?[0-9]{1,}(\.[0-9]{1,})?)\OPERATOR(\-?[0-9]{1,}(\.[0-9]{1,})?)";

        while (Regex.IsMatch(currentExpression, doubleOperatorRegex.Replace(@"\OPERATOR", @"[-+*/]")))
        {
            // Division - operator /
            currentExpression = Regex.Replace(currentExpression, doubleOperatorRegex.Replace("OPERATOR", "/"),
                m => EquateOperator(m, RollOperator.Division));
            // Multiplication - operator *
            currentExpression = Regex.Replace(currentExpression, doubleOperatorRegex.Replace("OPERATOR", "*"),
                m => EquateOperator(m, RollOperator.Multiplication));
            // Subtraction - operator -
            currentExpression = Regex.Replace(currentExpression, doubleOperatorRegex.Replace("OPERATOR", "-"),
                m => EquateOperator(m, RollOperator.Subtraction));
            // Addition - operator +
            currentExpression = Regex.Replace(currentExpression, doubleOperatorRegex.Replace("OPERATOR", "+"),
                m => EquateOperator(m, RollOperator.Addition));
        }

        #endregion

        if (!double.TryParse(currentExpression, NumberStyles.Any, CultureInfo.InvariantCulture, out var output))
            throw new UnsolvableEquationException(currentExpression);

        return output;
    }

    #region FormattingMethods

    private string EncaseInCurlyBrackets(Match match)
    {
        return $"{{{match.Groups[1].Value}}}{match.Groups[2].Value}";
    }

    #endregion

    #region FunctionMethods

    private string EquateFunction(Match match, RollFunction rollFunction)
    {
        double output = 0;

        var content = double.Parse(match.Groups[1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);

        output = rollFunction switch
        {
            RollFunction.Floor => Math.Floor(content),
            RollFunction.Ceiling => Math.Ceiling(content),
            RollFunction.Round => Math.Round(content, 0),
            RollFunction.Absolute => Math.Abs(content),
            _ => output
        };

        return output.ToString(CultureInfo.InvariantCulture);
    }

    #endregion

    #region SeparatorMethods

    private static bool DiceResultComparison(int result, string comparator, int comparedValue)
    {
        return comparator switch
        {
            ">" => result > comparedValue,
            ">=" => result >= comparedValue,
            "==" => result == comparedValue,
            "<=" => result <= comparedValue,
            "<" => result < comparedValue,
            "<>" => result != comparedValue,
            _ => throw new UnrecognizedModifierException(comparator)
        };
    }

    private string EquateCurlyBrackets(Match match)
    {
        var values = new List<double>();
        var staticValue = "";

        if (Regex.IsMatch(match.Groups[1].Value, @"^([0-9]+)d([0-9]+)(r(!)?(>|>=|=|<=|<|<>)([0-9]))?([\-\+\*\/\%\^][0-9]{1,}(\.[0-9]{1,})?)?$"))
        {
            var m1 = Regex.Match(match.Groups[1].Value, @"^([0-9]+)d([0-9]+)(r(!)?(>|>=|=|<=|<|<>)([0-9]))?([\-\+\*\/\%\^][0-9]{1,}(\.[0-9]{1,})?)?$");

            values.AddRange(EquateDice(m1));

            staticValue = m1.Groups[7].Value;
        }
        else
        {
            values = match.Groups[1].Value.Split(",").Select(x => Equate(x)).ToList();
        }

        var modifierSign = match.Groups[4].Value;
        var modifierValue = int.Parse(match.Groups[5].Value);

        values = modifierSign switch
        {
            "d" => values.OrderByDescending(x => x).Take(Math.Max(values.Count - modifierValue, 0)).ToList(),
            "dl" => values.OrderByDescending(x => x).Take(Math.Max(values.Count - modifierValue, 0)).ToList(),
            "dh" => values.OrderBy(x => x).Take(Math.Max(values.Count - modifierValue, 0)).ToList(),
            "k" => values.OrderBy(x => x).Take(Math.Max(modifierValue, 0)).ToList(),
            "kl" => values.OrderBy(x => x).Take(Math.Max(modifierValue, 0)).ToList(),
            "kh" => values.OrderByDescending(x => x).Take(Math.Max(modifierValue, 0)).ToList(),
            ">" => values.Where(x => x > modifierValue).ToList(),
            ">=" => values.Where(x => x >= modifierValue).ToList(),
            "<=" => values.Where(x => x <= modifierValue).ToList(),
            "<" => values.Where(x => x < modifierValue).ToList(),

            // Absolute has to be used because of comparison of floating point value and integer value
            "=" => values.Where(x => Math.Abs(x - modifierValue) < 0).ToList(),
            "<>" => values.Where(x => Math.Abs(x - modifierValue) > 0).ToList(),
            _ => throw new UnrecognizedModifierException(modifierSign)
        };


        return values.Sum(x => x).ToString(CultureInfo.InvariantCulture) + staticValue;
    }

    /// <summary>
    ///     Recursively evaluate sub-equations encased in parenthesis
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    private string EquateSeparatorParenthesis(Match match)
    {
        var output = Equate(match.Groups[1].Value);

        return $"({output.ToString(CultureInfo.InvariantCulture)})";
    }

    #endregion

    #region OperatorMethods

    private List<double> EquateDice(Match m1)
    {
        var output = new List<double>(0);

        var count = int.Parse(m1.Groups[1].Value);
        var faces = int.Parse(m1.Groups[2].Value);

        var reRoll = !string.IsNullOrEmpty(m1.Groups[3].Value);
        var reRollExplicit = m1.Groups[4].Value == "!";
        var reRollOperator = m1.Groups[5].Value;
        var reRollComparedValue = !string.IsNullOrEmpty(m1.Groups[6].Value) ? int.Parse(m1.Groups[6].Value) : 0;

        for (var i = 0; i < count; i++)
        {
            var result = _random.Next(1, faces + 1);

            if (reRoll && !DiceResultComparison(result, reRollOperator, reRollComparedValue))
                do
                {
                    result = _random.Next(1, faces + 1);
                } while (reRollExplicit && !DiceResultComparison(result, reRollOperator, reRollComparedValue));

            output.Add(_random.Next(1, faces + 1));
        }

        return output;
    }

    private string SumDice(Match match)
    {
        return EquateDice(match).Sum().ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     Calculates a result of a and b with a given operator
    /// </summary>
    /// <param name="match">The matching expression</param>
    /// <param name="rollOperator">The operator to calculate</param>
    /// <returns>The result as a string</returns>
    private string EquateNonDoubleOperator(Match match, RollOperator rollOperator)
    {
        double output = 0;

        var a = int.Parse(match.Groups[1].ToString());
        var b = int.Parse(match.Groups[2].ToString());

        output = rollOperator switch
        {
            RollOperator.Exponent => Math.Pow(a, b),
            RollOperator.Modulo => a % b,
            _ => output
        };

        return output.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     Calculates a result of a and b with a given operator
    /// </summary>
    /// <param name="match">The matching expression</param>
    /// <param name="rollOperator">The operator to calculate</param>
    /// <returns>The result as a string</returns>
    /// <exception cref="DivideByZeroException">Throwing if trying to divide by 0</exception>
    private string EquateOperator(Match match, RollOperator rollOperator)
    {
        double output = 0;

        var a = double.Parse(match.Groups[1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
        var b = double.Parse(match.Groups[3].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);


        if (b == 0 && (rollOperator == RollOperator.Division || rollOperator == RollOperator.Modulo))
            throw new DivideByZeroException();

        output = rollOperator switch
        {
            RollOperator.Division => a / b,
            RollOperator.Multiplication => a * b,
            RollOperator.Subtraction => a - b,
            RollOperator.Addition => a + b,
            _ => output
        };

        return output.ToString(CultureInfo.InvariantCulture);
    }

    #endregion
}