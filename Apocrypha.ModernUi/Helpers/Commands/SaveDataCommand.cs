using System;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Services.ViewModelConverter;
using Apocrypha.ModernUi.ViewModels.Common;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.Helpers.Commands;

public class SaveDataCommand<TViewModel, TModel> : IRelayCommand
    where TViewModel : BaseViewModel
    where TModel : DatabaseObject, new()
{
    private readonly IDataService<TModel> _dataService;
    private readonly IViewModelConverter<TViewModel, TModel> _viewModelConverter;

    public SaveDataCommand(IDataService<TModel> dataService, IViewModelConverter<TViewModel, TModel> viewModelConverter)
    {
        _dataService = dataService;
        _viewModelConverter = viewModelConverter;
    }

    public bool CanExecute(object parameter)
    {
        return parameter is TViewModel;
    }

    public async void Execute(object parameter)
    {
        if (parameter is not TViewModel viewModel)
            throw new ArgumentException();

        var databaseObject = await _viewModelConverter.ToModel(viewModel);

        if (databaseObject.Id == 0)
            await _dataService.Create(databaseObject);
        else
            await _dataService.Update(databaseObject.Id, databaseObject);
    }

    public event EventHandler CanExecuteChanged;

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}