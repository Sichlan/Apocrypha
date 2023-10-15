using System;
using System.Collections.Generic;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Resources.Localization;
using Apocrypha.ModernUi.Services.UserInformationService;
using Apocrypha.ModernUi.Services.ViewModelConverter;
using Apocrypha.ModernUi.ViewModels.Common;

namespace Apocrypha.ModernUi.Helpers.Commands.SaveData;

public class SaveDataCommand<TViewModel, TModel> : ISaveDataCommand
    where TViewModel : BaseViewModel
    where TModel : DatabaseObject, new()
{
    private readonly IDataService<TModel> _dataService;
    private readonly IViewModelConverter<TViewModel, TModel> _viewModelConverter;
    private readonly IUserInformationMessageService _userInformationMessageService;
    private readonly Func<bool> _canExecute;
    private bool _cancelExecution;

    private readonly IList<Action> _stagedActionsPreExecution;
    private readonly IList<Action> _stagedActionsPostExecution;

    public SaveDataCommand(IDataService<TModel> dataService, IViewModelConverter<TViewModel, TModel> viewModelConverter,
        IUserInformationMessageService userInformationMessageService, Func<bool> canExecute = null)
    {
        _dataService = dataService;
        _viewModelConverter = viewModelConverter;
        _userInformationMessageService = userInformationMessageService;
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

        _cancelExecution = false;

        foreach (var action in _stagedActionsPreExecution)
        {
            action();

            if (_cancelExecution)
                return;
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

        _userInformationMessageService.AddDisplayMessage(Localization.UserMessageSaveSuccessful, InformationType.Success, 5000);
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

    public void CancelExecution(bool cancelledByUser, string reason = "")
    {
        _cancelExecution = true;
        _userInformationMessageService.AddDisplayMessage(Localization.UserMessageExecutionCancelled,
            cancelledByUser ? InformationType.Warning : InformationType.Error, 5000, reason);
    }
}