using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.State.Navigators.Navigators
{
    public class ViewModelDelegateRenavigator<TViewModel> : IRenavigator where TViewModel : BaseViewModel
    {
        private readonly CreateViewModel<TViewModel> _createViewModel;
        private readonly INavigator _navigator;

        public ViewModelDelegateRenavigator(INavigator navigator, CreateViewModel<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}