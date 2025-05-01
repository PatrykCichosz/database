using Microsoft.EntityFrameworkCore;
using MmaApi.Models;

namespace MmaApi.Data
{
    public class MmaDbContext : DbContext
    {
        public MmaDbContext(DbContextOptions<MmaDbContext> options) : base(options) { }

        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<FightRecord> FightRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FightRecord>()
                .HasOne(fr => fr.Fighter)
                .WithMany()
                .HasForeignKey(fr => fr.FighterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FightRecord>()
                .HasOne(fr => fr.Opponent)
                .WithMany()
                .HasForeignKey(fr => fr.OpponentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
