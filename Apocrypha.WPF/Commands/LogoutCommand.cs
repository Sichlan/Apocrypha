using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators;

namespace Apocrypha.WPF.Commands;

public class LogoutCommand : AsyncCommandBase
{
    private readonly IAuthenticator _authenticator;
    private readonly IRenavigator _renavigator;
    private readonly ICharacterStore _characterStore;

    public LogoutCommand(IAuthenticator authenticator, IRenavigator renavigator, ICharacterStore characterStore)
    {
        _authenticator = authenticator;
        _renavigator = renavigator;
        _characterStore = characterStore;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        await _authenticator.Logout();
        _characterStore.CurrentCharacter = null;
        _renavigator.Renavigate();
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}