using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.SignalR.Client;
using TopDownHeist.Server;
using Xunit;

namespace TopDownHeist.IntegrationTests
{
    public class SignalRTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private const string HubLocation = "http://localhost/heistHub";
        private readonly WebApplicationFactory<Startup> _webApplicationFactory;

        public SignalRTests(WebApplicationFactory<Startup> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;

            // Required for population the Server property on the app factory
            _webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task SignalRConnectDisconnect()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl(HubLocation, transports =>
                {
                    transports.HttpMessageHandlerFactory = (handler) => _webApplicationFactory.Server.CreateHandler();
                })
                .Build();

            await connection.StartAsync();

            await connection.StopAsync();
        }
    }
}
