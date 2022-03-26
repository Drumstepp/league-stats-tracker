using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Drumstepp.Common.Interfaces;
using Drumstepp.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Drumstepp.GetChartData
{
    public class GetChartData
    {
        private readonly ILogger _logger;
        private readonly IChartDataService _chartDataService;

        public GetChartData(ILoggerFactory loggerFactory, IChartDataService chartDataService)
        {
            _logger = loggerFactory.CreateLogger<GetChartData>();
            _chartDataService = chartDataService;
        }

        [Function("GetChartData")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req, string user)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            if (String.IsNullOrWhiteSpace (user)) 
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }
            
            ICollection<DbChartData> dbChartData = await _chartDataService.GetDbChartDatas(user);
            ChartData sidesPlayed = _chartDataService.GetSidesPlayed(dbChartData);
            ChartData gameTypesPlayed = _chartDataService.GetGameTypesPlayed(dbChartData);
            ChartData championsPlayed = _chartDataService.GetChampionsPlayed(dbChartData);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");
            var json = JsonSerializer.Serialize(new ChartViewData { SideData = sidesPlayed, GameTypeData = gameTypesPlayed,  ChampionData = championsPlayed}, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            await response.WriteStringAsync(json);
            

            return response;
        }
    }
}
