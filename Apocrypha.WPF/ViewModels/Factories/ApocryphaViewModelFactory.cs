using System;
using Apocrypha.WPF.State;

namespace Apocrypha.WPF.ViewModels.Factories
{
    public class ApocryphaViewModelFactory : IApocryphaViewModelFactory
    {
        public ApocryphaViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModelFactory,
            CreateViewModel<CharacterSelectionViewModel> createCharacterSelectionViewModelFactory,
            CreateViewModel<LoginViewModel> createLoginViewModelFactory, CreateViewModel<RegistrationViewModel> createRegistrationViewModelFactory,
            CreateViewModel<DiceRollerViewModel> createDiceRollerViewModelFactory, CreateViewModel<CharacterProfileViewModel> createCharacterProfileViewModelFactory, CreateViewModel<SpellCardEditorViewModel> createSpellCardEditorViewModelFactory)
        {
            _createHomeViewModelFactory = createHomeViewModelFactory;
            _createCharacterSelectionViewModelFactory = createCharacterSelectionViewModelFactory;
            _createLoginViewModelFactory = createLoginViewModelFactory;
            _createRegistrationViewModelFactory = createRegistrationViewModelFactory;
            _createDiceRollerViewModelFactory = createDiceRollerViewModelFactory;
            _createCharacterProfileViewModelFactory = createCharacterProfileViewModelFactory;
            _createSpellCardEditorViewModelFactory = createSpellCardEditorViewModelFactory;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModelFactory();
                case ViewType.CharacterSelection:
                    return _createCharacterSelectionViewModelFactory();
                case ViewType.Login:
                    return _createLoginViewModelFactory();
                case ViewType.Register:
                    return _createRegistrationViewModelFactory();
                case ViewType.DiceRoller:
                    return _createDiceRollerViewModelFactory();
                case ViewType.Profile:
                    return _createCharacterProfileViewModelFactory();
                case ViewType.SpellCardEditor:
                    return _createSpellCardEditorViewModelFactory();
                default:
                    throw new ArgumentException("The view type does not have a view model", nameof(viewType));
            }
        }

        #region CreateViewModelDelegateFields

        private readonly CreateViewModel<HomeViewModel> _createHomeViewModelFactory;
        private readonly CreateViewModel<CharacterSelectionViewModel> _createCharacterSelectionViewModelFactory;
        private readonly CreateViewModel<CharacterProfileViewModel> _createCharacterProfileViewModelFactory;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModelFactory;
        private readonly CreateViewModel<RegistrationViewModel> _createRegistrationViewModelFactory;
        private readonly CreateViewModel<DiceRollerViewModel> _createDiceRollerViewModelFactory;
        private readonly CreateViewModel<SpellCardEditorViewModel> _createSpellCardEditorViewModelFactory;

        #endregion
    }
}