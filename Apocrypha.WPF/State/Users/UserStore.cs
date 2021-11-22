using System;
using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.State.Navigators.Users
{
    public class UserStore : IUserStore
    {
        private User currentUser;

        public User CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                StateChange?.Invoke();
            }
        }
        
        public event Action StateChange;
    }
}