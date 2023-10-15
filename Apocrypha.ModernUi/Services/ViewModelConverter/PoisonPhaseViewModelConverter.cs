using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.ViewModels.Tools;

namespace Apocrypha.ModernUi.Services.ViewModelConverter;

public class PoisonPhaseViewModelConverter : IViewModelConverter<PoisonPhaseViewModel, PoisonPhase>
{
    private readonly IViewModelConverter<PoisonPhaseElementViewModel, PoisonPhaseElement> _phaseElementConverter;
    private List<Condition> _conditions;
    private List<PoisonDuration> _poisonDurations;
    private List<PoisonDamageTarget> _poisonDamageTargets;
    private List<PoisonSpecialEffect> _poisonSpecialEffects;
    private readonly IDataService<PoisonPhase> _poisonPhaseDataService;

    public PoisonPhaseViewModelConverter(IViewModelConverter<PoisonPhaseElementViewModel, PoisonPhaseElement> phaseElementConverter,
        IDataService<Condition> conditionDataService,
        IDataService<PoisonDuration> durationDataService,
        IDataService<PoisonDamageTarget> damageTargetDataService,
        IDataService<PoisonSpecialEffect> specialEffectDataService,
        IDataService<PoisonPhase> poisonPhaseDataService)
    {
        _phaseElementConverter = phaseElementConverter;
        _poisonPhaseDataService = poisonPhaseDataService;

        Task.WaitAll(Task.Run(async () => _conditions = (await conditionDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonDurations = (await durationDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonDamageTargets = (await damageTargetDataService.GetAll()).ToList()),
            Task.Run(async () => _poisonSpecialEffects = (await specialEffectDataService.GetAll()).ToList()));
    }

    /// <inheritdoc />
    public async Task<PoisonPhaseViewModel> ToViewModel(PoisonPhase model)
    {
        var viewModel = new PoisonPhaseViewModel(_conditions, _poisonDurations, _poisonDamageTargets, _poisonSpecialEffects)
        {
            Id = model.Id,
            PhaseNumber = model.PhaseNumber,
            PhaseElements =
                new ObservableCollection<PoisonPhaseElementViewModel>(
                    await Task.WhenAll(model.PoisonPhaseElements.Select(async x => await _phaseElementConverter.ToViewModel(x)))),
            PoisonDurationId = model.PoisonPhaseDurationId
        };
        viewModel.SetupPhaseElementUpdateEventHandler();

        return viewModel;
    }

    public async Task<PoisonPhase> ToModel(PoisonPhaseViewModel viewModel)
    {
        var model = await _poisonPhaseDataService.GetById(viewModel.Id) ?? new PoisonPhase();

        model.Id = viewModel.Id;
        model.PhaseNumber = viewModel.PhaseNumber;
        model.PoisonPhaseElements = (await Task.WhenAll(viewModel.PhaseElements.Select(async x => await _phaseElementConverter.ToModel(x)))).ToList();
        model.PoisonPhaseDurationId = viewModel.PoisonDurationId;

        return model;
    }
}