using System;
using Apocrypha.WPF.State.Navigators;

namespace Apocrypha.WPF.ViewModels.Factories
{
    public class ApocryphaViewModelFactory : IApocryphaViewModelFactory
    {
        #region CreateViewModelDelegateFields

        private readonly CreateViewModel<HomeViewModel> _createHomeViewModelFactory;

        #endregion

        public ApocryphaViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModelFactory)
        {
            _createHomeViewModelFactory = createHomeViewModelFactory;
        }
        
        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModelFactory();
                default:
                    throw new ArgumentException("The view type does not have a view model", nameof(viewType));
            }
        }
    }
}