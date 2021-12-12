using System.Threading.Tasks;

namespace Apocrypha.CommonObject.Services.DiceRollerServices
{
    public interface IDiceRollerService
    {
        /// <summary>
        /// Evaluates the given expression into a double value.
        /// See <a href="https://github.com/Sichlan/Apocrypha/wiki/Dice-Rolls">here</a> for additional documentation
        /// </summary>
        /// <param name="equation">The equation to evaluate.</param>
        /// <returns></returns>
        Task<double> RollDice(string equation);
    }
}