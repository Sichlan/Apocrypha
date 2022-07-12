using System;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services.AuthenticationServices;
using Apocrypha.WPF.State.Users;

namespace Apocrypha.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserStore _userStore;

        public Authenticator(IAuthenticationService authenticationService, IUserStore userStore)
        {
            _authenticationService = authenticationService;
            _userStore = userStore;
        }

        public event Action StateChange;

        public User CurrentUser
        {
            get
            {
                return _userStore.CurrentUser;
            }
            private set
            {
                _userStore.CurrentUser = value;
                StateChange?.Invoke();
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return CurrentUser != null;
            }
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmnPassword)
        {
            return await _authenticationService.Register(email, username, password, confirmnPassword);
        }

        public async Task Login(string username, string password)
        {
            CurrentUser = await _authenticationService.Login(username, password);
        }

        public async Task<bool> Logout()
        {
            CurrentUser = null;

            return true;
        }
    }
}