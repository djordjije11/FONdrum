using FONdrum.API.Registrars.ServiceRegistrars;
using FONdrum.BusinessLogic.Operations.Wines.Queries.GetWines;
using MediatR.NotificationPublishers;

namespace Cineast.API.Registrars.ServiceRegistrars.BusinessLogic
{
    public class OperationsRegistrar : IServiceRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<GetWinesQuery>();
            });
        }
    }
}
