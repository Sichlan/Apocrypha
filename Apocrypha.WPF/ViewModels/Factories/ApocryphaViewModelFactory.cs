using System;
using Apocrypha.WPF.Resources.Localization;
using Apocrypha.WPF.State;

namespace Apocrypha.WPF.ViewModels.Factories
{
    public class ApocryphaViewModelFactory : IApocryphaViewModelFactory
    {
        public ApocryphaViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModelFactory,
            CreateViewModel<CharacterSelectionViewModel> createCharacterSelectionViewModelFactory,
            CreateViewModel<LoginViewModel> createLoginViewModelFactory, 
            CreateViewModel<RegistrationViewModel> createRegistrationViewModelFactory,
            CreateViewModel<DiceRollerViewModel> createDiceRollerViewModelFactory, 
            CreateViewModel<CharacterProfileViewModel> createCharacterProfileViewModelFactory, 
            CreateViewModel<SpellCardEditorViewModel> createSpellCardEditorViewModelFactory, 
            CreateViewModel<RaceEditorViewModel> createRaceEditorViewModelFactory, 
            CreateViewModel<RaceListViewModel> createRaceListViewModelFactory)
        {
            _createHomeViewModelFactory = createHomeViewModelFactory;
            _createCharacterSelectionViewModelFactory = createCharacterSelectionViewModelFactory;
            _createLoginViewModelFactory = createLoginViewModelFactory;
            _createRegistrationViewModelFactory = createRegistrationViewModelFactory;
            _createDiceRollerViewModelFactory = createDiceRollerViewModelFactory;
            _createCharacterProfileViewModelFactory = createCharacterProfileViewModelFactory;
            _createSpellCardEditorViewModelFactory = createSpellCardEditorViewModelFactory;
            _createRaceEditorViewModelFactory = createRaceEditorViewModelFactory;
            _createRaceListViewModelFactory = createRaceListViewModelFactory;
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
                case ViewType.RaceEditor:
                    return _createRaceEditorViewModelFactory();
                case ViewType.RaceList:
                    return _createRaceListViewModelFactory();
                default:
                    throw new ArgumentException(Localization.ErrorViewTypeNotReckognized, nameof(viewType));
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
        private readonly CreateViewModel<RaceEditorViewModel> _createRaceEditorViewModelFactory;
        private readonly CreateViewModel<RaceListViewModel> _createRaceListViewModelFactory;

        #endregion
    }
}