using System.Windows;

namespace Apocrypha.WPF.State.UserMessage;

public class MessageBoxUserMessageService : IUserMessageService
{
    /// <summary>
    /// Displays a default message box to the user.
    /// </summary>
    /// <inheritdoc/>
    public MessageBoxResult ShowMessage(string message,
        string caption,
        MessageBoxButton messageBoxButton,
        MessageBoxImage messageBoxImage,
        MessageBoxResult messageBoxResult,
        MessageBoxOptions messageBoxOptions)
    {
        return MessageBox.Show(message, caption, messageBoxButton, messageBoxImage, messageBoxResult, messageBoxOptions);
    }
}