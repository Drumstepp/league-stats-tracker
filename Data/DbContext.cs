using Drumstepp.Models;
using Microsoft.EntityFrameworkCore;

namespace Drumstepp.Data
{
    public class LolContext : DbContext
    {
        public LolContext(DbContextOptions<LolContext> options) : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<PlayerMatch> PlayerMatches { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<PlayerMatch>().ToTable("PlayerMatch");
            modelBuilder.Entity<Player>().ToTable("Player");
        }

    }
}