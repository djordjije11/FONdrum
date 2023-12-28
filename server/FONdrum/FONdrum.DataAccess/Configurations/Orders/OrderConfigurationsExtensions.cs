using Microsoft.EntityFrameworkCore;

namespace FONdrum.DataAccess.Configurations.Orders
{
    public static class OrderConfigurationsExtensions
    {
        public static void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new OrderConfiguration())
                .ApplyConfiguration(new OrderItemConfiguration());
        }
    }
}
