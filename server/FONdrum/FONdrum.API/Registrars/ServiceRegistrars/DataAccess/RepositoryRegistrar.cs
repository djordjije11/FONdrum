using FONdrum.DataAccess.Repositories;
using FONdrum.Domain.Repositories;

namespace FONdrum.API.Registrars.ServiceRegistrars.DataAccess;

public class RepositoryRegistrar : IServiceRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IWineRepository, WineRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    }
}
