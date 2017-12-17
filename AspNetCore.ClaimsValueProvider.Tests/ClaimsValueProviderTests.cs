using AspNetCore.ClaimsValueProvider.Tests.Server;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCore.ClaimsValueProvider.Tests
{
    public class ClaimsValueProviderTests : IClassFixture<ServerFixture>
    {
        private readonly HttpClient _client;

        public ClaimsValueProviderTests(ServerFixture server)
        {
            _client = server.Client;
        }

        [Fact]
        public async Task Test_ProvidesClaim()
        {
            // Arrange.
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/test")
            {
                Headers =
                {
                    Authorization =  new AuthenticationHeaderValue("TestAuth")
                }
            };

            // Act.
            var response = await _client.SendAsync(request);

            // Assert.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("testValue", await response.Content.ReadAsStringAsync());
        }
    }
}
