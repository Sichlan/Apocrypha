using System.Globalization;
using Apocrypha.CommonObject.Models.Common.Translation;

namespace Apocrypha.WPF.Commands.TranslationCommands;

public class AddNewTranslationEntryCommand<T> : AsyncCommandBase where T : Translation<T>, new()
{
    private readonly ICollection<T> _translationCollection;

    public AddNewTranslationEntryCommand(ICollection<T> translationCollection)
    {
        _translationCollection = translationCollection;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        _translationCollection.Add(new T()
        {
            CultureInfo = CultureInfo.CurrentCulture
        });
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}