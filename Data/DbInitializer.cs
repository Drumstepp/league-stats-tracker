using Drumstepp.Models;
using System;
using System.Linq;

namespace Drumstepp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LolContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}