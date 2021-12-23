using Apocrypha.CommonObject.Models;
using Apocrypha.WPF.State.Navigators;

namespace Apocrypha.WPF.State.Users
{
    public interface IUserStore : IStateChanger
    {
        User CurrentUser { get; set; }
    }
}