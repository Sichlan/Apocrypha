using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Exceptions;

namespace Apocrypha.CommonObject.Services.DiceRollerServices
{
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

        public async Task<double> RollDice(string equation)
        {
            double output = 0;
            string currentExpression = equation;

            
            //todo: equate expressions in brackets before calling these functions
            #region Functions

            string functionRegex = @"FUNCTION\((\-?[0-9]{1,}(\.[0-9]{1,})?)\)";
            
            //Floor - function floor(x)
            currentExpression = Regex.Replace(currentExpression, functionRegex.Replace("FUNCTION", "floor"), m => EquateFunction(m, RollFunction.Floor));
            //Ceiling - function ceil(x)
            currentExpression = Regex.Replace(currentExpression, functionRegex.Replace("FUNCTION", "ceil"), m => EquateFunction(m, RollFunction.Ceiling));
            //Round - function round(x)
            currentExpression = Regex.Replace(currentExpression, functionRegex.Replace("FUNCTION", "round"), m => EquateFunction(m, RollFunction.Round));
            //Absolute - function abs(x)
            currentExpression = Regex.Replace(currentExpression, functionRegex.Replace("FUNCTION", "abs"), m => EquateFunction(m, RollFunction.Absolute));

            #endregion

            // remove brackets around single numbers
            // e. g. (20.9) => 20.9, (20+9) stays unchanged
            currentExpression = Regex.Replace(currentExpression, @"\(([0-9]{1,}(\.[0-9]{1,})?)\)", m => m.Groups[1].ToString());
            
            #region Operators

            string diceRegex = @"([0-9]{1,})d([0-9]{1,})";
            // Dice - operator d
            currentExpression = Regex.Replace(currentExpression, diceRegex, (m) => EquateDice(m));

            string nonDoubleOperatorRegex = @"(\-?[0-9]{1,})\OPERATOR(\-?[0-9]{1,})";
            // Exponent - operator ^
            currentExpression = Regex.Replace(currentExpression, nonDoubleOperatorRegex.Replace("OPERATOR", "^"), (m) => EquateNonDoubleOperator(m, RollOperator.Exponent));
            // Modulo - operator %
            currentExpression = Regex.Replace(currentExpression, nonDoubleOperatorRegex.Replace("OPERATOR", "%"), (m) => EquateNonDoubleOperator(m, RollOperator.Modulo));

            string doubleOperatorRegex = @"(\-?[0-9]{1,}(\.[0-9]{1,})?)\OPERATOR(\-?[0-9]{1,}(\.[0-9]{1,})?)";
            // Division - operator /
            currentExpression = Regex.Replace(currentExpression, doubleOperatorRegex.Replace("OPERATOR", "/"), (m) => EquateOperator(m, RollOperator.Division));
            // Multiplication - operator *
            currentExpression = Regex.Replace(currentExpression, doubleOperatorRegex.Replace("OPERATOR", "*"), (m) => EquateOperator(m, RollOperator.Multiplication));
            // Subtraction - operator -
            currentExpression = Regex.Replace(currentExpression, doubleOperatorRegex.Replace("OPERATOR", "-"), (m) => EquateOperator(m, RollOperator.Subtraction));
            // Addition - operator +
            currentExpression = Regex.Replace(currentExpression, doubleOperatorRegex.Replace("OPERATOR", "+"), (m) => EquateOperator(m, RollOperator.Addition));

            #endregion

            if (!double.TryParse(currentExpression, NumberStyles.Any, CultureInfo.InvariantCulture, out output))
            {  
                throw new UnsolvableEquationException(currentExpression);
            }
            
            return output; 
        }

        
        
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
        
        
        
        #region OperatorMethods

        private string EquateDice(Match match)
        {
            double output = 0;

            int a = int.Parse(match.Groups[1].ToString());
            int b = int.Parse(match.Groups[2].ToString());
            
            for (int i = 0; i < a; i++)
            {
                output += _random.Next(1, b + 1);
            }

            return output.ToString(CultureInfo.InvariantCulture);
        }
        
        /// <summary>
        /// Calculates a result of a and b with a given operator 
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
        /// Calculates a result of a and b with a given operator 
        /// </summary>
        /// <param name="match">The matching expression</param>
        /// <param name="rollOperator">The operator to calculate</param>
        /// <returns>The result as a string</returns>
        /// <exception cref="DivideByZeroException">Throwing if trying to divide by 0</exception>
        private string EquateOperator(Match match, RollOperator rollOperator)
        {
            double output = 0;

            double a = double.Parse(match.Groups[1].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);
            double b = double.Parse(match.Groups[3].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture);

            
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
}