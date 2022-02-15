using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Drumstepp.FetchMatches
{
    public class FetchMatches
    {
        private readonly ILogger _logger;
        private readonly ICollection<String> TrackedSummoners = new List<String> {"0n02GnQsUl40poJ9ewCHc5wwRD2YdJ9s6sV-p7qhPOarc5YVru8gd_Dd8EGkZwnxiTBQeoX6wohXRQ"};

        public FetchMatches(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FetchMatches>();
        }

        [Function("FetchMatches")]
        public void Run([TimerTrigger("0 */5 * * * *")] MyInfo myTimer)
        {
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
