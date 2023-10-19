using System;
using Apocrypha.CommonObject.Models;

namespace Apocrypha.ModernUi.Services.State.Users;

public class UserStore : IUserStore
{
    private User _currentUser;

    public User CurrentUser
    {
        get => _currentUser;
        set
        {
            _currentUser = value;
            StateChange?.Invoke();
        }
    }

    public event Action StateChange;
}