using System.Diagnostics;

namespace Apocrypha.ModernUi.Services;

/// <inheritdoc/>
public class DebugUserInformationMessageService : IUserInformationMessageService
{
    /// <inheritdoc/>
    public void AddDisplayMessage(string message, InformationType type, int deleteAfter = -1, string messageDetails = "")
    {
        Debug.WriteLine(
            $"[{type.ToString()[..3].ToUpper()}]: {message} {(deleteAfter > 0 ? $"({deleteAfter} sec.)" : "")}{(!string.IsNullOrEmpty(messageDetails) ? $"\n - {messageDetails}" : "")}");
    }
}