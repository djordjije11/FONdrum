using FONdrum.DTO.Mapping.Profiles.Wines;

namespace FONdrum.API.Registrars.ServiceRegistrars.Models
{
    public class MappingModelsRegistrar : IServiceRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(WinesMappingProfile).Assembly);
        }
    }
}
