using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.ViewModels.Navigation.Tools;

namespace Apocrypha.ModernUi.Services.ViewModelConverter;

public class PoisonPhaseViewModelConverter : IViewModelConverter<PoisonPhaseViewModel, PoisonPhase>
{
    private readonly IViewModelConverter<PoisonPhaseElementViewModel, PoisonPhaseElement> _phaseElementConverter;
    private List<Condition> _conditions;
    private List<PoisonDuration> _poisonDurations;
    private List<PoisonDamageTarget> _poisonDamageTargets;
    private List<PoisonSpecialEffect> _poisonSpecialEffects;

    public PoisonPhaseViewModelConverter(IViewModelConverter<PoisonPhaseElementViewModel, PoisonPhaseElement> phaseElementConverter,
        IDataService<Condition> conditionDataService,
        IDataService<PoisonDuration> durationDataService,
        IDataService<PoisonDamageTarget> damageTargetDataService,
        IDataService<PoisonSpecialEffect> specialEffectDataService)
    {
        _phaseElementConverter = phaseElementConverter;

        Task.WaitAll(Task.Run(async () => _conditions = (await conditionDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonDurations = (await durationDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonDamageTargets = (await damageTargetDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonSpecialEffects = (await specialEffectDataService.GetAll()).ToList()));
    }

    public PoisonPhaseViewModel ToViewModel(PoisonPhase model)
    {
        var viewModel = new PoisonPhaseViewModel(_conditions, _poisonDurations, _poisonDamageTargets, _poisonSpecialEffects)
        {
            Id = model.Id,
            PhaseNumber = model.PhaseNumber,
            PhaseElements =
                new ObservableCollection<PoisonPhaseElementViewModel>(model.PoisonPhaseElements.Select(x => _phaseElementConverter.ToViewModel(x))),
            SelectedPoisonDuration = model.PoisonPhaseDuration
        };
        viewModel.SetupPhaseElementUpdateEventHandler();

        return viewModel;
    }

    public PoisonPhase ToModel(PoisonPhaseViewModel viewModel)
    {
        return new PoisonPhase()
        {
            Id = viewModel.Id,
            PhaseNumber = viewModel.PhaseNumber,
            PoisonPhaseElements = viewModel.PhaseElements.Select(x => _phaseElementConverter.ToModel(x)).ToList(),
            PoisonPhaseDuration = viewModel.SelectedPoisonDuration
        };
    }
}