using Microsoft.EntityFrameworkCore;

namespace FONdrum.DataAccess.Configurations.Wines
{
    public static class WineConfigurationsExtensions
    {
        public static void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new WineStyleConfiguration())
                .ApplyConfiguration(new GrapeVarietyConfiguration())
                .ApplyConfiguration(new WineConfiguration());
        }
    }
}
