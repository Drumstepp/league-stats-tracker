using System;
using System.Collections.Generic;
using Drumstepp.FetchMatches.Interfaces;
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

namespace Drumstepp.FetchMatches.Services
{
    public class RiotApiService : IRiotApiService
    {
        private LolContext _context;
        private HttpClient _client;
        public RiotApiService(LolContext context, IHttpClientFactory client)
        {
            _context = context;
            _client = client.CreateClient();
            _client.DefaultRequestHeaders.Add("X-Riot-Token", Environment.GetEnvironmentVariable("RiotApiKey"));
            _client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("RiotApiUrl"));
        }

        public async Task<ICollection<String>> GetMatchesByPUUID(string PUUID) 
        {
            return await _client.GetFromJsonAsync<String[]>($"/lol/match/v5/matches/by-puuid/{PUUID}/ids");
        }


        public async Task<Match> GetMatch(string matchId)
        {
            RiotMatch riotMatch = await _client.GetFromJsonAsync<RiotMatch>($"/lol/match/v5/matches/{matchId}");
            return new Match {
                MatchId = matchId,
                GameStart = DateTimeOffset.FromUnixTimeMilliseconds(riotMatch.Info.GameStartTimeStamp).UtcDateTime,
                GameEnd = DateTimeOffset.FromUnixTimeMilliseconds(riotMatch.Info.GameEndTimeStamp).UtcDateTime,
                GameMode = riotMatch.Info.GameMode
            };

        }

    }
}
