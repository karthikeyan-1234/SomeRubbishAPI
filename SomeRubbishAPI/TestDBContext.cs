using Microsoft.EntityFrameworkCore;

using SomeRubbishAPI.Models;

namespace SomeRubbishAPI
{
    public class TestDBContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options)
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
            modelBuilder.Entity<Employee>().ToTable("tblemployee");
            modelBuilder.Entity<Employee>().HasKey(e => e.ID);
            modelBuilder.Entity<Employee>().Property(e => e.FirstName).HasColumnName("first_Name");
            modelBuilder.Entity<Employee>().Property(e => e.LastName).HasColumnName("last_Name");
        }
    }
}
