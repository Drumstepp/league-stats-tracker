using System;
using System.Collections.Generic;
using Drumstepp.Common.Interfaces;
using Drumstepp.Common;
using Drumstepp.Models;
using Drumstepp.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Drumstepp.Common.Services
{
    public class ChartDataService : IChartDataService
    {
        private LolContext _context;
        public ChartDataService(LolContext context)
        {
            _context = context;
        }

        public async Task<ICollection<DbChartData>> GetDbChartDatas(string user) 
        {
            return await _context.PlayerMatches.Where(x => x.Player.Name == user).Select((x) =>
            new DbChartData 
            {
                Name = x.Player.Name,
                SidePlayed = x.SidePlayed,
                SecondsSpentCCd = x.TimeSpentCCD,
                Won = x.Won,
                ChampionName = x.ChampionName,
                GameStart = x.Match.GameStart,
                GameEnd = x.Match.GameEnd,
                GameMode = x.Match.GameMode,
                MatchId = x.Match.MatchId

            }).OrderBy(x => x.GameStart).ToListAsync();
        }

        public ChartData GetSidesPlayed(ICollection<DbChartData> dbChartData) 
        {   
            int blueSideGames = dbChartData.Count(x => x.SidePlayed == SidePlayed.BLUE);
            int redSideGames = dbChartData.Count(x => x.SidePlayed == SidePlayed.RED);
            return new ChartData
            {
                Labels = new String[] {$"Red ({redSideGames})", $"Blue ({blueSideGames})"},
                Datasets = new ChartDataSets[] 
                {
                    new ChartDataSets 
                    {
                        Label = "Games by side played",
                        Data = new int[] { redSideGames, blueSideGames },
                        BackgroundColor = new String[] { "rgb(255, 99, 132)", "rgb(100, 60, 255)" },
                        BorderColor = new String[] { "rgb(255, 99, 132)", "rgb(100, 60, 255)" },
                        BorderWidth = 1
                    }
                }
            };
        }

        public ChartData GetGameTypesPlayed(ICollection<DbChartData> dbChartData) 
        {   

            List<Tuple<String, int>> gameTypeCounts = 
            dbChartData.GroupBy(x => x.GameMode)
            .Select(cl => new Tuple<string, int>(cl.First().GameMode, cl.Count()))
            .ToList();

            // https://stackoverflow.com/questions/11120840/hash-string-into-rgb-color
            var labels = new List<String> {};
            var data = new List<int> {};          
            var colors = new List<String> {};
        

            gameTypeCounts.ForEach(x => {
                labels.Add(x.Item1);
                data.Add(x.Item2);
                colors.Add(x.Item1.ToRgbString());
            });

            return new ChartData
            {
                Labels = labels.ToArray(),
                Datasets = new ChartDataSets[] 
                {
                    new ChartDataSets 
                    {
                        Label = "Games By Mode Played",
                        Data = data.ToArray(),
                        BackgroundColor = colors.ToArray(),
                        BorderColor = colors.ToArray(),
                        BorderWidth = 1
                    }
                }
                
            };
        }

    }
}
