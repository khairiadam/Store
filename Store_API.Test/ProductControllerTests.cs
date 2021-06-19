using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Store_Shared.Models;
using Xunit;

namespace Store_API.Test
{
    public class ProductControllerTests: IntegrationTest
    {
        [Fact]
        public async Task GetAll()
        {
            // await AuthenticateAsync();

            var response = await _testClient.GetAsync("Https://localhost:3001/api/Product");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var resultString = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<Product>>(resultString);
            result.Should().NotBeEmpty();
        }
    }
}