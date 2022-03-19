using System;
using System.Collections.Generic;
using Drumstepp.Common.Interfaces;
using Drumstepp.Models;
using Drumstepp.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Net.Http.Json;

namespace Drumstepp.Common.Services
{
    public class RiotApiService : IRiotApiService
    {
        private HttpClient _client;
        public RiotApiService(IHttpClientFactory client)
        {
            _client = client.CreateClient();
            _client.DefaultRequestHeaders.Add("X-Riot-Token", Environment.GetEnvironmentVariable("RiotApiKey"));
            _client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("RiotApiUrl"));
        }

        public async Task<ICollection<String>> GetMatchesByPUUID(string PUUID, int count = 20, int start = 0) 
        {
            return await _client.GetFromJsonAsync<String[]>($"/lol/match/v5/matches/by-puuid/{PUUID}/ids?count={count}&start={start}");
        }

        public async Task<RiotMatch> GetRiotMatch(string matchId)
        {
            return await _client.GetFromJsonAsync<RiotMatch>($"/lol/match/v5/matches/{matchId}");
        }

    }
}
