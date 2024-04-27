using FONdrum.DataAccess.Configurations.Orders;
using FONdrum.DataAccess.Configurations.Wines;
using FONdrum.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FONdrum.DataAccess
{
    public class FONdrumContext : DbContext
    {
        public FONdrumContext(DbContextOptions<FONdrumContext> options) : base(options)
        {
        }

        public DbSet<Wine> Wines { get; set; }
        public DbSet<WineStyle> WineStyles { get; set; }
        public DbSet<GrapeVariety> GrapeVarieties { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            WineConfigurationsExtensions.ApplyConfigurations(modelBuilder);
            OrderConfigurationsExtensions.ApplyConfigurations(modelBuilder);
        }
    }
}
