using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Store_Shared.Helpers;

namespace Store_Client_Blzr.Services.AuthService
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationState _state;


        public AuthProvider(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationState state)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _state = state;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrWhiteSpace(token))
                return _state;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(
                new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        }


        public void NotifyUserAuthentication(string email)
        {
            var authenticatedUser =
                new ClaimsPrincipal(new ClaimsIdentity(new[] {new Claim(ClaimTypes.Name, email)}, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }


        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_state);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}