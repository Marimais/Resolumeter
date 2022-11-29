using Microsoft.AspNetCore.Components.Authorization;

namespace ResoluApp.Services
{
    public class Identify
    {
        private AuthenticationStateProvider _authenticationState;
        public  Identify(AuthenticationStateProvider AuthenticationState)
        {
            _authenticationState = AuthenticationState;
        }

        public async Task<string?> GetUserName()
        {
            var authenticationState = await _authenticationState.GetAuthenticationStateAsync();
            var user = authenticationState.User;
            var username= user!.Identity!.Name;
            return username;
        }
       
    }
}
