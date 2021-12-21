using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.CommonObject.Services.DiceRollerServices;
using Apocrypha.WPF.Commands;
using ICSharpCode.AvalonEdit.Document;

namespace Apocrypha.WPF.ViewModels
{
    public class DiceRollerViewModel : BaseViewModel
    {
        private readonly IDiceRollerService _diceRollerService;

        private string _output;

        public DiceRollerViewModel(IDiceRollerService diceRollerService)
        {
            _diceRollerService = diceRollerService;
            ClearHistoryCommand = new RelayCommand(s => Output = "", s => true);
            RollDiceCommand = new RelayCommand(async s => ExecuteNewRoll(s), s => true);
        }

        public TextDocument TextDocument { get; set; } = new("");

        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                OnPropertyChanged(nameof(Output));
            }
        }

        public ICommand RollDiceCommand { get; set; }
        public ICommand ClearHistoryCommand { get; set; }

        private async Task ExecuteNewRoll(object o)
        {
            var result = await _diceRollerService.RollDice(TextDocument.Text);

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
    }
}