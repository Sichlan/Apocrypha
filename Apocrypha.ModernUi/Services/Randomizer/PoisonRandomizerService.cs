using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;

namespace Apocrypha.ModernUi.Services.Randomizer;

public class PoisonRandomizerService : IPoisonRandomizerService
{
    private readonly Random _random;
    private readonly IDataService<PoisonDeliveryMethod> _poisonDeliveryMethodService;
    private readonly IDataService<PoisonDuration> _poisonDurationService;

    public PoisonRandomizerService(Random random, IDataService<PoisonDeliveryMethod> poisonDeliveryMethodService,
        IDataService<PoisonDuration> poisonDurationService)
    {
        _random = random;
        _poisonDeliveryMethodService = poisonDeliveryMethodService;
        _poisonDurationService = poisonDurationService;
    }

    public async Task<Poison> GenerateRandomPoison()
    {
        var deliveryMethods = (await _poisonDeliveryMethodService.GetAll()).ToList();
        var durations = (await _poisonDurationService.GetAll()).ToList();


        var phases = new List<PoisonPhase>();

        var phaseNumber = 1;

        do
        {
            var phaseElements = new List<PoisonPhaseElement>();

            do
            {
                var element = new PoisonPhaseElement()
                {
                    //todo
                };

                phaseElements.Add(element);
            } while (_random.Next(0, 2) == 0);

            var phase = new PoisonPhase()
            {
                PhaseNumber = phaseNumber,
                PoisonPhaseElements = phaseElements,
                PoisonPhaseDurationId = phaseNumber == 1 ? null : durations[_random.Next(0, durations.Count)].Id
            };

            phases.Add(phase);

            phaseNumber++;
        } while (_random.Next(0, 2) == 0);

        var poison = new Poison()
        {
            CreatorId = null,
            Toxicity = (int)Math.Floor(Math.Log(_random.Next(), 1.2) * 0.45 - 10),
            DeliveryMethodId = deliveryMethods[_random.Next(0, deliveryMethods.Count)].Id,
            Phases = phases
        };

        return poison;
    }
}