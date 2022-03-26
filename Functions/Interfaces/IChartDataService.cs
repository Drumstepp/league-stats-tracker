using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Drumstepp.Models;

namespace Drumstepp.Common.Interfaces
{
    public interface IChartDataService
    {
        public Task<ICollection<DbChartData>> GetDbChartDatas(string user);
        public ChartData GetSidesPlayed(ICollection<DbChartData> dbChartData);
        public ChartData GetGameTypesPlayed(ICollection<DbChartData> dbChartData);
        public ChartData GetChampionsPlayed(ICollection<DbChartData> dbChartData);
    }
}