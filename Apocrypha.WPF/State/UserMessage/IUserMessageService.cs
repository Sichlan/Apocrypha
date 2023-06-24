using System.Windows;

namespace Apocrypha.WPF.State.UserMessage;

public interface IUserMessageService
{
    /// <summary>
    /// Shows a message to the user.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="caption">The caption of the message window.</param>
    /// <param name="messageBoxButton">The buttons displayed in the message box window.</param>
    /// <param name="messageBoxImage">The image to display in the messagebox.</param>
    /// <param name="defaultMessageBoxResult">The default message box option, whose button should be keyboard focused.</param>
    /// <param name="messageBoxOptions">Options for the message box.</param>
    /// <returns>A message box result depending on the users choice.</returns>
    public MessageBoxResult ShowMessage(string message,
        string caption,
        MessageBoxButton messageBoxButton,
        MessageBoxImage messageBoxImage,
        MessageBoxResult defaultMessageBoxResult,
        MessageBoxOptions messageBoxOptions);
}