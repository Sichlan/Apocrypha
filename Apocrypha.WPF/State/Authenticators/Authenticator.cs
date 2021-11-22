using System;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services.AuthenticationServices;
using Apocrypha.WPF.State.Navigators.Users;

namespace Apocrypha.WPF.State.Navigators.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        public event Action StateChange;
        private readonly IUserStore _userStore;
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService, IUserStore userStore)
        {
            _authenticationService = authenticationService;
            _userStore = userStore;
        }

        public User CurrentUser
        {
            get => _userStore.CurrentUser;
            private set
            {
                _userStore.CurrentUser = value;
                StateChange?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentUser != null;
        
        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmnPassword)
        {
            return await _authenticationService.Register(email, username, password, confirmnPassword);
        }

        public async Task Login(string username, string password)
        {
            CurrentUser = await _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}