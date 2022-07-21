using Apocrypha.WPF.State;

namespace Apocrypha.WPF.ViewModels.Factories;

public interface IApocryphaViewModelFactory
{
    BaseViewModel CreateViewModel(ViewType viewType);
}