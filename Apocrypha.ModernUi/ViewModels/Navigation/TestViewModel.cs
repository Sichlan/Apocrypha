using System.Windows.Input;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;
using Apocrypha.ModernUi.Services.UserInformationService;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Navigation;

public class TestViewModel : NavigableViewModel
{
    private readonly IUserInformationMessageService _userInformationMessageService;
    public override string ViewModelTitle { get; } = Localization.TestViewModelTitle;
    public ICommand SendUserTestMessageCommand { get; }

    public TestViewModel(NavigateToPageCommand navigateToPageCommand,
        IUserInformationMessageService userInformationMessageService)
        : base(navigateToPageCommand)
    {
        _userInformationMessageService = userInformationMessageService;

        SendUserTestMessageCommand = new RelayCommand(ExecuteSendUserTestMessageCommand);
    }

    private void ExecuteSendUserTestMessageCommand()
    {
        _userInformationMessageService.AddDisplayMessage("TEST MESSAGE", InformationType.Error, -1, "TEST CONTENT");
    }
}