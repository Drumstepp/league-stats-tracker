using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Drumstepp.FetchMatches.Interfaces;
using Drumstepp.FetchMatches.Services;

namespace league_stats_tracker
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s => {
                    s.AddSingleton<IMatchService, MatchService>();
                })
                .Build();

            host.Run();
        }
    }
}