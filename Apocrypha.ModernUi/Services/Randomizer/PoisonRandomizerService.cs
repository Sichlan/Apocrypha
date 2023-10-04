using System;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Poisons;

namespace Apocrypha.ModernUi.Services.Randomizer;

public class PoisonRandomizerService : IPoisonRandomizerService
{
    private readonly Random _random;

    public PoisonRandomizerService(Random random)
    {
        _random = random;
    }

    public async Task<Poison> GenerateRandomPoison()
    {
        throw new NotImplementedException();
    }
}