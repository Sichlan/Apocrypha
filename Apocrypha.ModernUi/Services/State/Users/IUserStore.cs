using Apocrypha.CommonObject.Models;

namespace Apocrypha.ModernUi.Services.State.Users;

public interface IUserStore : IStateChanger
{
    User CurrentUser { get; set; }
}