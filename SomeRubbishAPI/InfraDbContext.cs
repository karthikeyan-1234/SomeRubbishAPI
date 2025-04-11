using Microsoft.EntityFrameworkCore;

using SomeRubbishAPI.Models;

namespace SomeRubbishAPI
{
    public class InfraDbContext: DbContext
    {
        public DbSet<Network> Networks { get; set; }
        public DbSet<Switch> Switches { get; set; }
        public DbSet<Computer> Computers { get; set; }

        public InfraDbContext(DbContextOptions<InfraDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var networkEntity = modelBuilder.Entity<Network>().ToTable("Networks");
            var switchEntity = modelBuilder.Entity<Switch>().ToTable("Switches");
            var computerEntity = modelBuilder.Entity<Computer>().ToTable("Computers");

            networkEntity.HasKey(n => n.Id).IsClustered();
            switchEntity.HasKey(s => s.Id).IsClustered();
            computerEntity.HasKey(c => c.Id).IsClustered();

            networkEntity.HasMany(n => n.Switches).WithOne(s => s.Network).HasForeignKey(s => s.NetworkId);
            switchEntity.HasMany(s => s.Computers).WithOne(c => c.Switch).HasForeignKey(c => c.SwitchId);
            computerEntity.HasOne(c => c.Switch).WithMany(s => s.Computers).HasForeignKey(c => c.SwitchId);
        }
    }
}
