using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.State.Users;

public interface IUserStore : IStateChanger
{
    User CurrentUser { get; set; }
}