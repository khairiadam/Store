using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Store_Shared.Models;
using Xunit;

namespace Store_API.Test
{
    public class CategoriesControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll()
        {
            // await AuthenticateAsync();

            var response = await _testClient.GetAsync("Https://localhost:3001/api/Category");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var resultString = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<Category>>(resultString);
            result.Should().NotBeEmpty();
        }


        [Fact]
        public async Task GetById()
        {
            // await AuthenticateAsync();

            var response =
                await _testClient.GetAsync(
                    "Https://localhost:3001/api/Category/GetCategory?id=0b0e93a8-c379-4da1-b50d-5addaba1e4e3");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadAsStringAsync();
            //var result = await JsonSerializer.SerializeAsync(resultString);
            result.Should().NotBeNull();
        }
    }
}