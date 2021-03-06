using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Drumstepp.Common.Interfaces;
using System.Threading.Tasks;
using Drumstepp.Models;
using System.Linq;
using System.Threading;

namespace Drumstepp.FetchMatches
{
    public class FetchMatches
    {
        private readonly ILogger _logger;
        private readonly IMatchService _matchService;
        private readonly IRiotApiService _riotApiService;
        private readonly IPlayerService _playerService;
        private readonly IPlayerMatchService _playerMatchService;

        public FetchMatches(ILoggerFactory loggerFactory,
        IMatchService matchService,
        IRiotApiService riotApiService,
        IPlayerService playerService,
        IPlayerMatchService playerMatchService)
        {
            _logger = loggerFactory.CreateLogger<FetchMatches>();
            _matchService = matchService;
            _riotApiService = riotApiService;
            _playerService = playerService;
            _playerMatchService = playerMatchService;
        }

        [Function("FetchMatches")]
        public async Task Run([TimerTrigger("0 */10 * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"Timer last fired at: " + myTimer.ScheduleStatus.Last);
            var playerList = await _playerService.GetPlayers();
            foreach (var player in playerList)
            {
                var matchList = await _riotApiService.GetMatchesByPUUID(player.PUUID);
                // ICollection<String> matchesNotInDb = await _matchService.GetMatchesNotInDb(matchList);
                foreach (var matchId in matchList)
                {
                    if (!await _matchService.GetMatchExists(matchId))
                    {
                        RiotMatch rm = await _riotApiService.GetRiotMatch(matchId);
                        if (rm.Info.GameMode == "PRACTICETOOL") return;
                        
                        Match m = new Match
                        {
                            MatchId = matchId,
                            GameStart = DateTimeOffset.FromUnixTimeMilliseconds(rm.Info.GameStartTimeStamp).UtcDateTime,
                            GameEnd = DateTimeOffset.FromUnixTimeMilliseconds(rm.Info.GameEndTimeStamp).UtcDateTime,
                            GameMode = rm.Info.GameMode

                        };
                        var matchAdded = await _matchService.AddMatch(m);

                        var participantInfo = rm.Info.Participants.FirstOrDefault(x => x.PUUID == player.PUUID);
                        try
                        {
                            PlayerMatch pm = new PlayerMatch
                            {
                                PositionPlayed = Enum.Parse<PositionPlayed>(String.IsNullOrWhiteSpace(participantInfo.IndividualPosition) ? "Invalid" : participantInfo.IndividualPosition),
                                SidePlayed = participantInfo.TeamId == 100 ? SidePlayed.BLUE : SidePlayed.RED,
                                TimeSpentCCD = participantInfo.TotalTimeCCDealt,
                                Won = participantInfo.Win,
                                ChampionName = participantInfo.ChampionName,
                                Match = matchAdded,
                                Player = player
                            };
                            await _playerMatchService.AddPlayerMatch(pm);
                        }
                        catch (Exception e)
                        {
                            _logger.LogError($"Error while creating PlayerMatch object. Player is {player.Name}, matchId is {matchId}, Position is {participantInfo.IndividualPosition}");
                            throw;
                        }

                    }
                    else if (!await _playerMatchService.GetPlayerMatchExists(matchId, player.PUUID))
                    {
                        RiotMatch rm = await _riotApiService.GetRiotMatch(matchId);
                        Match m = await _matchService.GetMatch(matchId);
                        var participantInfo = rm.Info.Participants.FirstOrDefault(x => x.PUUID == player.PUUID);
                        try
                        {
                            PlayerMatch pm = new PlayerMatch
                            {
                                PositionPlayed = Enum.Parse<PositionPlayed>(String.IsNullOrWhiteSpace(participantInfo.IndividualPosition) ? "Invalid" : participantInfo.IndividualPosition),
                                SidePlayed = participantInfo.TeamId == 100 ? SidePlayed.BLUE : SidePlayed.RED,
                                TimeSpentCCD = participantInfo.TotalTimeCCDealt,
                                Won = participantInfo.Win,
                                ChampionName = participantInfo.ChampionName,
                                Match = m,
                                Player = player
                            };
                            await _playerMatchService.AddPlayerMatch(pm);
                        }
                        catch (Exception e)
                        {
                            _logger.LogError($"Error while creating PlayerMatch object. Player is {player.Name}, matchId is {matchId}, Position is {participantInfo.IndividualPosition}");
                            throw;
                        }
                    }



                }
            }

        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
