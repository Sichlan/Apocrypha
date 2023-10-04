using System;
using System.Collections.Generic;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Services.ViewModelConverter;
using Apocrypha.ModernUi.ViewModels.Common;

namespace Apocrypha.ModernUi.Helpers.Commands.SaveData;

public class SaveDataCommand<TViewModel, TModel> : ISaveDataCommand<TViewModel, TModel>
    where TViewModel : BaseViewModel
    where TModel : DatabaseObject, new()
{
    private readonly IDataService<TModel> _dataService;
    private readonly IViewModelConverter<TViewModel, TModel> _viewModelConverter;
    private readonly Func<bool> _canExecute;

    private readonly IList<Action> _stagedActionsPreExecution;
    private readonly IList<Action> _stagedActionsPostExecution;

    public SaveDataCommand(IDataService<TModel> dataService, IViewModelConverter<TViewModel, TModel> viewModelConverter, Func<bool> canExecute = null)
    {
        _dataService = dataService;
        _viewModelConverter = viewModelConverter;
        _canExecute = canExecute;

        _stagedActionsPreExecution = new List<Action>();
        _stagedActionsPostExecution = new List<Action>();
    }

    public bool CanExecute(object parameter)
    {
        return parameter is TViewModel
               && (_canExecute == null || _canExecute());
    }

    public async void Execute(object parameter)
    {
        if (parameter is not TViewModel viewModel)
            throw new ArgumentException();

        foreach (var action in _stagedActionsPreExecution)
        {
            action();
        }

        var databaseObject = await _viewModelConverter.ToModel(viewModel);

        if (databaseObject.Id == 0)
            await _dataService.Create(databaseObject);
        else
            await _dataService.Update(databaseObject.Id, databaseObject);

        foreach (var action in _stagedActionsPostExecution)
        {
            action();
        }
    }

    public event EventHandler CanExecuteChanged;

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public void StagePreExecutionAction(Action action)
    {
        _stagedActionsPreExecution.Add(action);
    }

    public void StagePostExecutionAction(Action action)
    {
        _stagedActionsPostExecution.Add(action);
    }
}