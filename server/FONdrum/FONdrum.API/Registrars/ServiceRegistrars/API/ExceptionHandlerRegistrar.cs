
using FONdrum.API.Middlewares;

namespace FONdrum.API.Registrars.ServiceRegistrars.API
{
    public class ExceptionHandlerRegistrar : IServiceRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ExceptionHandlingMiddleware>();
        }
    }
}
