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

            if (context.Players.Any()) {
                return;
            }

            var players = new Player[] {
                new Player{PUUID = "0n02GnQsUl40poJ9ewCHc5wwRD2YdJ9s6sV-p7qhPOarc5YVru8gd_Dd8EGkZwnxiTBQeoX6wohXRQ", Name = "Drumstepp" },
                new Player{PUUID = "XYt0Y_mFSOzyWdsOLFc_90REBX0kJiNFEoHhiP9LxNurguN7_e_l3i4uJmhmGvgj_9AhfaDfe3aVpA", Name = "Hockomock" },
                new Player{PUUID = "HNMGAkUN3PIk6c6_qWhId9EyYm6hGecqsxdCvDZv9NQ37l97U4qaq4ivril9cjApjCk7UnPxMxFmqw", Name = "Jikan Kama" },
                new Player{PUUID = "ubcbWwrLYzLAOVAUFWeLu1ZJ8847tpWepcgLzMsJAGqdqVbaK58XM9EzH31F7bckCC2DH891xHAUvw", Name = "ShadowedHearts" },
                new Player{PUUID = "E7aRfmWlJEcAZzDwl7Dg03yXRuMigd711JzDzg6qAuO9fm1KHrzbo-Z5HKGH4yHFNcNOUvORW8GzQA", Name = "squeakysylveon" }
            };
            context.Players.AddRange(players);
            context.SaveChanges();
        }
    }
}