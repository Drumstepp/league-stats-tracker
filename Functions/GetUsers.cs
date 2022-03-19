using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Drumstepp.Common.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Drumstepp.GetUsers
{
    public class GetUsers
    {
        private readonly ILogger _logger;
        private readonly IPlayerService _playerService;

        public GetUsers(ILoggerFactory loggerFactory, IPlayerService playerService)
        {
            _logger = loggerFactory.CreateLogger<GetUsers>();
            _playerService = playerService;
        }

        [Function("GetUsers")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var players = await _playerService.GetPlayers();

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(players.Select(x => x.Name).ToArray());

            return response;
        }
    }
}
