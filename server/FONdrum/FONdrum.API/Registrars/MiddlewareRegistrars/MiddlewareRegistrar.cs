using FONdrum.API.Middlewares;
using FONdrum.API.Seeding;

namespace FONdrum.API.Registrars.MiddlewareRegistrars
{
    public static class MiddlewareRegistrar
    {
        public static void RegisterMiddlewares(WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                SeederFactory.Handle(app);
            }
            app.UseHttpsRedirection();

            app.UseCors(app.Configuration.GetRequiredSection("CORS:PolicyName").Get<string>());

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
