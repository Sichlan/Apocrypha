using System.Threading.Tasks;
using Apocrypha.CommonObject.Models.Common;
using Apocrypha.ModernUi.ViewModels.Common;

namespace Apocrypha.ModernUi.Services.ViewModelConverter;

/// <summary>
/// An interface that defines methods to convert a view model into it's model counterpart and vice versa.
/// </summary>
/// <typeparam name="TViewModel">The type of the view model.</typeparam>
/// <typeparam name="TModel">The type of the model.</typeparam>
public interface IViewModelConverter<TViewModel, TModel>
    where TViewModel : BaseViewModel
    where TModel : DatabaseObject, new()
{
    /// <summary>
    /// Converts a <typeparamref name="TModel"/> into a <typeparamref name="TViewModel"/>.
    /// </summary>
    /// <param name="model">The model to convert</param>
    /// <returns>The converted view model</returns>
    Task<TViewModel> ToViewModel(TModel model);

    /// <summary>
    /// Converts a <typeparamref name="TViewModel"/> into a <typeparamref name="TModel"/>.
    /// </summary>
    /// <param name="viewModel">The view model to convert</param>
    /// <returns>The converted model</returns>
    Task<TModel> ToModel(TViewModel viewModel);
}