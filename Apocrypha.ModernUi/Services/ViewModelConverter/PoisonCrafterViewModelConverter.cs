using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.ViewModels.Common;
using Apocrypha.ModernUi.ViewModels.Tools;

namespace Apocrypha.ModernUi.Services.ViewModelConverter;

/// <inheritdoc />
public class PoisonCrafterViewModelConverter : IViewModelConverter<PoisonCrafterViewModel, Poison>
{
    private readonly CreateViewModel<PoisonCrafterViewModel> _createViewModel;

    private readonly IDataService<Poison> _poisonDataService;
    private readonly IViewModelConverter<PoisonPhaseViewModel, PoisonPhase> _poisonPhaseViewModelConverter;

    public PoisonCrafterViewModelConverter(IDataService<Poison> poisonDataService,
        IViewModelConverter<PoisonPhaseViewModel, PoisonPhase> poisonPhaseViewModelConverter,
        CreateViewModel<PoisonCrafterViewModel> createViewModel)
    {
        _poisonDataService = poisonDataService;
        _poisonPhaseViewModelConverter = poisonPhaseViewModelConverter;
        _createViewModel = createViewModel;
    }

    /// <inheritdoc />
    public async Task<PoisonCrafterViewModel> ToViewModel(Poison model)
    {
        var viewModel = _createViewModel();

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

    /// <inheritdoc />
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