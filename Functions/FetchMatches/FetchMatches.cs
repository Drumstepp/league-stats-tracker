using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Drumstepp.FetchMatches.Interfaces;

namespace Drumstepp.FetchMatches
{
    public class FetchMatches
    {
        private readonly ILogger _logger;
        private readonly IMatchService _matchService;
        private readonly ICollection<String> TrackedSummoners = new List<String> {"0n02GnQsUl40poJ9ewCHc5wwRD2YdJ9s6sV-p7qhPOarc5YVru8gd_Dd8EGkZwnxiTBQeoX6wohXRQ"};

        public FetchMatches(ILoggerFactory loggerFactory, IMatchService matchService)
        {
            _logger = loggerFactory.CreateLogger<FetchMatches>();
            _matchService = matchService;
        }

        [Function("FetchMatches")]
        public void Run([TimerTrigger("*/5 * * * * *")] MyInfo myTimer)
        {
            _matchService.GetMatchHistory("");
            
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
