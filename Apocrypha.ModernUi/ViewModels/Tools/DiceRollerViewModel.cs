using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.CommonObject.Exceptions;
using Apocrypha.CommonObject.Services.DiceRollerServices;
using Apocrypha.ModernUi.Helpers;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;
using Apocrypha.ModernUi.Services.UserInformationService;
using Apocrypha.ModernUi.ViewModels.Navigation;
using CommunityToolkit.Mvvm.Input;
using ICSharpCode.AvalonEdit.Document;

namespace Apocrypha.ModernUi.ViewModels.Tools;

public class DiceRollerViewModel : NavigableViewModel
{
    private readonly IDiceRollerService _diceRollerService;
    private readonly IUserInformationMessageService _userInformationMessageService;
    private string _output;
    private TextDocument _textDocument = new("tc2r7[3d4+6]");

    public override string ViewModelTitle => Localization.DiceRollerViewModelTitle;

    public TextDocument TextDocument
    {
        get => _textDocument;
        set
        {
            if (Equals(value, _textDocument))
                return;

            _textDocument = value;
            OnPropertyChanged();
        }
    }

    public string Output
    {
        get => _output;
        set
        {
            if (value == _output)
                return;

            _output = value;
            OnPropertyChanged();
        }
    }

    public ICommand RollEquationCommand { get; }
    public ICommand OpenHelpCommand { get; }

    public DiceRollerViewModel(NavigateToPageCommand navigateToPageCommand, IDiceRollerService diceRollerService,
        IUserInformationMessageService userInformationMessageService)
        : base(navigateToPageCommand)
    {
        _diceRollerService = diceRollerService;
        _userInformationMessageService = userInformationMessageService;

        RollEquationCommand = new RelayCommand(ExecuteRollEquationCommand, CanExecuteRollEquationCommand);
        OpenHelpCommand = new RelayCommand(ExecuteOpenHelpCommand, CanExecuteOpenHelpCommand);
    }

    private bool CanExecuteOpenHelpCommand()
    {
        return true;
    }

    private void ExecuteOpenHelpCommand()
    {
        UrlHelper.OpenUrl("https://github.com/Sichlan/Apocrypha/wiki/Dice-Rolls");
    }

    private bool CanExecuteRollEquationCommand()
    {
        return true;
    }

    private async void ExecuteRollEquationCommand()
    {
        var text = TextDocument.Text;

        await Task.Run(async () =>
        {
            try
            {
                var result = await _diceRollerService.RollDice(text);

                var textResult = "";

                for (var i = 0; i < result.Count; i++)
                {
                    var text = $"Roll {1 + i}: ";

                    for (var j = 0; j < result[i].Count; j++)
                        text += (text.EndsWith(": ") ? "" : ", ") + result[i][j];

                    textResult += "\n" + text;
                }

                Output = textResult.Trim('\n') + "\n-----\n" + Output;
            }
            catch (UnsolvableEquationException e)
            {
                _userInformationMessageService.AddDisplayMessage(Localization.ExceptionMessageUnsolvableEquation, InformationType.Error,
                    messageDetails: string.Format(Localization.ExceptionMessageUnsolvableEquationDetails, e.Equation));
            }
        });
    }
}