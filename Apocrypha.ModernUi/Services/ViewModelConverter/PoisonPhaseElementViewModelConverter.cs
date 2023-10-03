using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.ViewModels.Navigation.Tools;

namespace Apocrypha.ModernUi.Services.ViewModelConverter;

public class PoisonPhaseElementViewModelConverter : IViewModelConverter<PoisonPhaseElementViewModel, PoisonPhaseElement>
{
    private List<Condition> _conditions;
    private List<PoisonDuration> _poisonDurations;
    private List<PoisonDamageTarget> _poisonDamageTargets;
    private List<PoisonSpecialEffect> _poisonSpecialEffects;
    private IDataService<PoisonPhaseElement> _poisonPhaseElementDataService;

    public PoisonPhaseElementViewModelConverter(IDataService<Condition> conditionDataService,
        IDataService<PoisonDuration> durationDataService,
        IDataService<PoisonDamageTarget> damageTargetDataService,
        IDataService<PoisonSpecialEffect> specialEffectDataService,
        IDataService<PoisonPhaseElement> poisonPhaseElementDataService)
    {
        _poisonPhaseElementDataService = poisonPhaseElementDataService;

        Task.WaitAll(Task.Run(async () => _conditions = (await conditionDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonDurations = (await durationDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonDamageTargets = (await damageTargetDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonSpecialEffects = (await specialEffectDataService.GetAll()).ToList()));
    }

    public async Task<PoisonPhaseElementViewModel> ToViewModel(PoisonPhaseElement model)
    {
        return new PoisonPhaseElementViewModel(_conditions, _poisonDurations, _poisonDamageTargets, _poisonSpecialEffects)
        {
            Id = model.Id,
            DamageDiceSize = model.DamageDiceSize,
            DamageDiceCount = model.DamageDiceCount,
            Condition = model.Condition,
            PoisonDuration = model.PoisonDuration,
            PoisonDamageTarget = model.PoisonDamageTarget,
            PoisonSpecialEffect = model.PoisonSpecialEffect
        };
    }

    public async Task<PoisonPhaseElement> ToModel(PoisonPhaseElementViewModel viewModel)
    {
        var model = await _poisonPhaseElementDataService.GetById(viewModel.Id) ?? new PoisonPhaseElement();

        model.Id = viewModel.Id;
        model.DamageDiceSize = viewModel.DamageDiceSize;
        model.DamageDiceCount = viewModel.DamageDiceCount;
        model.Condition = _conditions.FirstOrDefault(x => x.Id == viewModel.Condition?.Id);
        model.PoisonDuration = _poisonDurations.FirstOrDefault(x => x.Id == viewModel.PoisonDuration?.Id);
        model.PoisonDamageTarget = _poisonDamageTargets.FirstOrDefault(x => x.Id == viewModel.PoisonDamageTarget?.Id);
        model.PoisonSpecialEffect = _poisonSpecialEffects.FirstOrDefault(x => x.Id == viewModel.PoisonSpecialEffect?.Id);

        return model;
    }
}