using Apocrypha.CommonObject.Models.Common;
using Apocrypha.ModernUi.ViewModels.Common;

namespace Apocrypha.ModernUi.Services.ViewModelConverter;

public interface IViewModelConverter<TViewModel, TModel>
    where TViewModel : BaseViewModel
    where TModel : DatabaseObject, new()
{
    TViewModel ToViewModel(TModel model);
    TModel ToModel(TViewModel viewModel);
}