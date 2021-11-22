using Apocrypha.WPF.State.Navigators;

namespace Apocrypha.WPF.ViewModels.Factories
{
    public interface IApocryphaViewModelFactory
    {
        BaseViewModel CreateViewModel(ViewType viewType);
    }
}