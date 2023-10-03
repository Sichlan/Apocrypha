using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.ViewModels.Display.Tools;

namespace Apocrypha.ModernUi.Services.ViewModelConverter;

public class PoisonPhaseElementViewModelConverter : IViewModelConverter<PoisonPhaseElementViewModel, PoisonPhaseElement>
{
    private List<Condition> _conditions;
    private List<PoisonDuration> _poisonDurations;
    private List<PoisonDamageTarget> _poisonDamageTargets;
    private List<PoisonSpecialEffect> _poisonSpecialEffects;
    private readonly IDataService<PoisonPhaseElement> _poisonPhaseElementDataService;

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
            ConditionId = model.ConditionId,
            PoisonDurationId = model.PoisonDurationId,
            PoisonDamageTargetId = model.PoisonDamageTargetId,
            PoisonSpecialEffectId = model.PoisonSpecialEffectId
        };
    }

    public async Task<PoisonPhaseElement> ToModel(PoisonPhaseElementViewModel viewModel)
    {
        var model = await _poisonPhaseElementDataService.GetById(viewModel.Id) ?? new PoisonPhaseElement();

        model.Id = viewModel.Id;
        model.DamageDiceSize = viewModel.DamageDiceSize;
        model.DamageDiceCount = viewModel.DamageDiceCount;
        model.ConditionId = viewModel.ConditionId;
        model.PoisonDurationId = viewModel.PoisonDurationId;
        model.PoisonDamageTargetId = viewModel.PoisonDamageTargetId;
        model.PoisonSpecialEffectId = viewModel.PoisonSpecialEffectId;

        return model;
    }
}