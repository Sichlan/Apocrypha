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

    public PoisonPhaseElementViewModelConverter(IDataService<Condition> conditionDataService,
        IDataService<PoisonDuration> durationDataService,
        IDataService<PoisonDamageTarget> damageTargetDataService,
        IDataService<PoisonSpecialEffect> specialEffectDataService)
    {
        Task.WaitAll(Task.Run(async () => _conditions = (await conditionDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonDurations = (await durationDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonDamageTargets = (await damageTargetDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonSpecialEffects = (await specialEffectDataService.GetAll()).ToList()));
    }

    public PoisonPhaseElementViewModel ToViewModel(PoisonPhaseElement model)
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

    public PoisonPhaseElement ToModel(PoisonPhaseElementViewModel viewModel)
    {
        return new PoisonPhaseElement()
        {
            Id = viewModel.Id,
            DamageDiceSize = viewModel.DamageDiceSize,
            DamageDiceCount = viewModel.DamageDiceCount,
            Condition = viewModel.Condition,
            PoisonDuration = viewModel.PoisonDuration,
            PoisonDamageTarget = viewModel.PoisonDamageTarget,
            PoisonSpecialEffect = viewModel.PoisonSpecialEffect
        };
    }
}