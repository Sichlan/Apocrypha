using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.State.Users;

public class UserStore : IUserStore
{
    private User _currentUser;

    public User CurrentUser
    {
        get
        {
            return _currentUser;
        }
        set
        {
            _currentUser = value;
            StateChange?.Invoke();
        }
    }

    public event Action StateChange;
}