using Drumstepp.FetchMatches.Interfaces;
using Drumstepp.FetchMatches.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Drumstepp.FetchMatches.Startup))]

namespace Drumstepp.FetchMatches
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IMatchService, MatchService>();
        }
    }
}