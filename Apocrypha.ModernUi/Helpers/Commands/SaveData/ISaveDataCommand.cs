using Apocrypha.CommonObject.Models.Common;
using Apocrypha.ModernUi.ViewModels.Common;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.Helpers.Commands.SaveData;

public interface ISaveDataCommand<TViewModel, TModel> : IRelayCommand, IStageActionCommand
    where TViewModel : BaseViewModel
    where TModel : DatabaseObject, new()
{
}