
using FONdrum.API.Http.Headers;

namespace FONdrum.API.Registrars.ServiceRegistrars.API
{
    public class CorsRegistrar : IServiceRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: builder.Configuration.GetRequiredSection("CORS:PolicyName").Get<string>(),
                                  policy =>
                                  {
                                      string[] origins = builder.Configuration.GetRequiredSection("CORS:Origins").Get<string[]>();
                                      foreach (var origin in origins)
                                      {
                                          policy.WithOrigins(origin);
                                      }

                                      policy.AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .WithExposedHeaders(PaginationHeaders.Get())
                                            .AllowCredentials();
                                  });
            });
        }
    }
}
