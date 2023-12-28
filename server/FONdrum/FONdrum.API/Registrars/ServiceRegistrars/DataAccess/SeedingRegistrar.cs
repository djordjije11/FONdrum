using Cineast.Seeding;
using FONdrum.Seeding.Wines;

namespace FONdrum.API.Registrars.ServiceRegistrars.DataAccess
{
    public class SeedingRegistrar : IServiceRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<Seeder>();
            builder.Services.AddScoped<WineSeeder>();
        }
    }
}
