using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Course_Signup_System.Presentation.Services
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public CustomAuthProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService ;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetItemAsync<string>("authToken");
            if (string.IsNullOrWhiteSpace(token))
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            var handle = new JwtSecurityTokenHandler();
            var jwttoken = handle.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwttoken.Claims);
            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }
        public void NotifyUserAuthentication(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims);
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        public void NotifyUserLogout()
        {
            var anymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anymous)));
        }
    }
}
