using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Drumstepp.FetchMatches.Interfaces;
using Microsoft.EntityFrameworkCore;
using Drumstepp.FetchMatches.Services;
using Drumstepp.Data;
using System;
using Microsoft.Extensions.Logging;

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
                    s.AddSingleton<IRiotApiService, RiotApiService>();
                    s.AddSingleton<IPlayerService, PlayerService>();
                    s.AddSingleton<IPlayerMatchService, PlayerMatchService>();
                    s.AddDbContext<LolContext>(options => {
                        options.UseSqlServer(Environment.GetEnvironmentVariable("DbConn"));
                    });
                    s.AddHttpClient();
                    s.AddDatabaseDeveloperPageExceptionFilter();
                })
                .Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<LolContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                    throw;
                }
            }
        }
    }
}