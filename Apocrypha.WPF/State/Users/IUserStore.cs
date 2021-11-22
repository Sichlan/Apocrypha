using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.State.Navigators.Users
{
    public interface IUserStore : IStateChanger
    {
        User CurrentUser { get; set; }
    }
}