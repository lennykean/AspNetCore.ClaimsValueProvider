using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace AspNetCore.ClaimsValueProvider.Tests.Server
{
    public class ServerFixture : IDisposable
    {
        private TestServer _server;

        public ServerFixture()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            Client = _server.CreateClient();
        }

        public HttpClient Client { get; }


        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
