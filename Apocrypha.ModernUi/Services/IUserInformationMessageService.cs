namespace Apocrypha.ModernUi.Services;

public enum InformationType
{
    Information,
    Warning,
    Error
}

/// <summary>
/// Defines methods for displaying messages to the user. 
/// </summary>
public interface IUserInformationMessageService
{
    /// <summary>
    /// Displays a message to the user, using a style appropriate to the message type.
    /// </summary>
    /// <param name="message">The message the user should instantly see.</param>
    /// <param name="type">The appropriate type for this message.</param>
    /// <param name="deleteAfter">If bigger than 0, the message will disappear from UI in this amount of seconds.</param>
    /// <param name="messageDetails">If the message contains more content than appropriate for a header, set it here.</param>
    public void AddDisplayMessage(string message, InformationType type, int deleteAfter = -1, string messageDetails = "");
}