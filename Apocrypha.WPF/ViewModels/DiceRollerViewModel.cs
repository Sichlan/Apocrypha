using Apocrypha.CommonObject.Services.DiceRollerServices;
using Apocrypha.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apocrypha.WPF.ViewModels
{
    public class DiceRollerViewModel : BaseViewModel
    {
        private readonly IDiceRollerService _diceRollerService;

        public DiceRollerViewModel(IDiceRollerService diceRollerService)
        {
            _diceRollerService = diceRollerService;
            ClearHistoryCommand = new RelayCommand(s => Output = "", s => true);
            RollDiceCommand = new RelayCommand(async s => ExecuteNewRoll(s), s => true);
        }

        private async Task ExecuteNewRoll(object o)
        {
            var result = await _diceRollerService.RollDice(Expression);

            string textResult = "";
            for (int i = 0; i < result.Count; i++)
            {
                string text = $"Roll {1 + i}: ";

                for (int j = 0; j < result[i].Count; j++)
                {
                    text += (text.EndsWith(": ") ? "" : ", ") + result[i][j];
                }

                textResult += "\n" + text;
            }

            Output = textResult.Trim('\n') + "\n-----\n" + Output;
        }

        private string _expression;
        public string Expression
        {
            get { return _expression; }
            set { _expression = value; OnPropertyChanged(nameof(Expression)); }
        }

        private string _output;
        public string Output
        {
            get { return _output; }
            set { _output = value; OnPropertyChanged(nameof(Output)); }
        }

        public ICommand RollDiceCommand { get; set; }
        public ICommand ClearHistoryCommand { get; set; }
        
        
    }
}
