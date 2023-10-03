using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.ViewModels.Navigation.Tools;

namespace Apocrypha.ModernUi.Services.ViewModelConverter;

public class PoisonCrafterViewModelConverter : IViewModelConverter<PoisonCrafterViewModel, Poison>
{
    private readonly NavigateToPageCommand _navigateToPageCommand;
    private readonly IDataService<Poison> _poisonDataService;
    private readonly IDataService<PoisonDeliveryMethod> _poisonDeliveryMethodDataService;
    private readonly IViewModelConverter<PoisonPhaseViewModel, PoisonPhase> _poisonPhaseViewModelConverter;
    private readonly IDataService<Condition> _conditionDataService;
    private readonly IDataService<PoisonDuration> _durationDataService;
    private readonly IDataService<PoisonDamageTarget> _damageTargetDataService;
    private readonly IDataService<PoisonSpecialEffect> _specialEffectDataService;

    public PoisonCrafterViewModelConverter(NavigateToPageCommand navigateToPageCommand,
        IDataService<Poison> poisonDataService,
        IDataService<PoisonDeliveryMethod> poisonDeliveryMethodDataService,
        IViewModelConverter<PoisonPhaseViewModel, PoisonPhase> poisonPhaseViewModelConverter,
        IDataService<Condition> conditionDataService,
        IDataService<PoisonDuration> durationDataService,
        IDataService<PoisonDamageTarget> damageTargetDataService,
        IDataService<PoisonSpecialEffect> specialEffectDataService)
    {
        _navigateToPageCommand = navigateToPageCommand;
        _poisonDataService = poisonDataService;
        _poisonDeliveryMethodDataService = poisonDeliveryMethodDataService;
        _poisonPhaseViewModelConverter = poisonPhaseViewModelConverter;
        _conditionDataService = conditionDataService;
        _durationDataService = durationDataService;
        _damageTargetDataService = damageTargetDataService;
        _specialEffectDataService = specialEffectDataService;
    }

    public async Task<PoisonCrafterViewModel> ToViewModel(Poison model)
    {
        if (model == null)
            return new PoisonCrafterViewModel(_navigateToPageCommand, _poisonDataService, this, _poisonDeliveryMethodDataService, _conditionDataService,
                _durationDataService, _damageTargetDataService, _specialEffectDataService);

        return new PoisonCrafterViewModel(_navigateToPageCommand, _poisonDataService, this, _poisonDeliveryMethodDataService, _conditionDataService,
            _durationDataService, _damageTargetDataService, _specialEffectDataService)
        {
            Id = model.Id,
            PoisonTranslations = model.PoisonTranslations,
            Name = model.Name,
            Description = model.Description,
            DeliveryMethod = model.DeliveryMethod,
            Toxicity = model.Toxicity,
            PoisonPhases = new ObservableCollection<PoisonPhaseViewModel>(
                await Task.WhenAll(model.Phases.Select(async x => await _poisonPhaseViewModelConverter.ToViewModel(x))))
        };
    }

    public async Task<Poison> ToModel(PoisonCrafterViewModel viewModel)
    {
        var model = await _poisonDataService.GetById(viewModel.Id) ?? new Poison();

        model.Id = viewModel.Id;
        model.PoisonTranslations = viewModel.PoisonTranslations;
        model.Name = viewModel.Name;
        model.Description = viewModel.Description;
        model.DeliveryMethod = await _poisonDeliveryMethodDataService.GetById(viewModel.DeliveryMethod.Id);
        model.Toxicity = viewModel.Toxicity;
        model.Phases = (await Task.WhenAll(viewModel.PoisonPhases.Select(async x => await _poisonPhaseViewModelConverter.ToModel(x)))).ToList();

        return model;
    }
}