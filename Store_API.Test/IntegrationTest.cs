using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Store_API.Data;
using Microsoft.EntityFrameworkCore;
using Store_Shared.Dto;
using Xunit;

namespace Store_API.Test
{
    public class IntegrationTest
    {
        protected readonly HttpClient _testClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _testClient = appFactory.CreateClient();
        }

        // protected async Task AuthenticateAsync()
        // {
        //     _testClient.DefaultRequestHeaders.Authorization =
        //         new AuthenticationHeaderValue("bearer", await GetJwtTokenAsync());
        // }

        // private async Task<string> GetJwtTokenAsync()
        // {
        //     var login = new TokenRequestModel
        //     {
        //         Email = "test@integration.com",
        //         Password = "Password1!"
        //     };
        //     // var jsonLogin = JsonSerializer.SerializeAsync(login);
        //     // var response = await _testClient.PostAsAsync("Https://localhost:3001/api/Auth/Login", );
        //
        //     var registrationResponse = await response.Content.ReadFromJsonAsync<AuthModel>();
        //     return registrationResponse.Token;
        // }
    }
}