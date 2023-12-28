using FONdrum.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FONdrum.API.Registrars.ServiceRegistrars.DataAccess
{
    public class DbContextRegistrar : IServiceRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<FONdrumContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
                );
        }
    }
}
