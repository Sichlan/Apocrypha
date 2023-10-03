using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Services.State.Navigation;
using Apocrypha.ModernUi.ViewModels.Display.Tools;
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
    private readonly IDataService<PoisonPhase> _poisonPhaseDataService;
    private readonly INavigationService _navigationService;

    public PoisonCrafterViewModelConverter(NavigateToPageCommand navigateToPageCommand,
        IDataService<Poison> poisonDataService,
        IDataService<PoisonDeliveryMethod> poisonDeliveryMethodDataService,
        IViewModelConverter<PoisonPhaseViewModel, PoisonPhase> poisonPhaseViewModelConverter,
        IDataService<Condition> conditionDataService,
        IDataService<PoisonDuration> durationDataService,
        IDataService<PoisonDamageTarget> damageTargetDataService,
        IDataService<PoisonSpecialEffect> specialEffectDataService,
        IDataService<PoisonPhase> poisonPhaseDataService,
        INavigationService navigationService)
    {
        _navigateToPageCommand = navigateToPageCommand;
        _poisonDataService = poisonDataService;
        _poisonDeliveryMethodDataService = poisonDeliveryMethodDataService;
        _poisonPhaseViewModelConverter = poisonPhaseViewModelConverter;
        _conditionDataService = conditionDataService;
        _durationDataService = durationDataService;
        _damageTargetDataService = damageTargetDataService;
        _specialEffectDataService = specialEffectDataService;
        _poisonPhaseDataService = poisonPhaseDataService;
        _navigationService = navigationService;
    }

    public async Task<PoisonCrafterViewModel> ToViewModel(Poison model)
    {
        var viewModel = new PoisonCrafterViewModel(_navigateToPageCommand,
            _poisonDataService,
            this,
            _poisonDeliveryMethodDataService,
            _conditionDataService,
            _durationDataService,
            _damageTargetDataService,
            _specialEffectDataService,
            _poisonPhaseDataService,
            _navigationService);

        if (model != null)
        {
            viewModel.Id = model.Id;
            viewModel.PoisonTranslations = model.PoisonTranslations;
            viewModel.Name = model.Name;
            viewModel.Description = model.Description;
            viewModel.DeliveryMethodId = model.DeliveryMethodId;
            viewModel.CreatorId = model.CreatorId;
            viewModel.Toxicity = model.Toxicity;
            viewModel.PoisonPhases = new ObservableCollection<PoisonPhaseViewModel>(
                await Task.WhenAll(model.Phases.Select(async x => await _poisonPhaseViewModelConverter.ToViewModel(x))));
        }

        return viewModel;
    }

    public async Task<Poison> ToModel(PoisonCrafterViewModel viewModel)
    {
        if (viewModel.DeliveryMethodId == null)
            throw new InvalidOperationException("DeliveryMethodId must be set to a viable value");

        var model = await _poisonDataService.GetById(viewModel.Id) ?? new Poison();

        model.Id = viewModel.Id;
        model.PoisonTranslations = viewModel.PoisonTranslations;
        model.Name = viewModel.Name;
        model.Description = viewModel.Description;
        model.DeliveryMethodId = viewModel.DeliveryMethodId;
        model.CreatorId = viewModel.CreatorId;
        model.Toxicity = viewModel.Toxicity;
        model.Phases = (await Task.WhenAll(viewModel.PoisonPhases.Select(async x => await _poisonPhaseViewModelConverter.ToModel(x)))).ToList();

        return model;
    }
}