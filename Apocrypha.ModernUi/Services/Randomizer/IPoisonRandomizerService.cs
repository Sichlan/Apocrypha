using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Poisons;

namespace Apocrypha.ModernUi.Services.Randomizer;

public interface IPoisonRandomizerService
{
    Task<Poison> GenerateRandomPoison();
}