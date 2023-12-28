namespace FONdrum.API.Registrars.ServiceRegistrars.API
{
    public class ControllerRegistrar : IServiceRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
        }
    }
}
