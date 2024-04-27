using FONdrum.API.Registrars.MiddlewareRegistrars;
using FONdrum.API.Registrars.ServiceRegistrars;

namespace FONdrum.API.Registrars
{
    public static class RegistrarExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder, Type scanningType)
        {
            var serviceRegistrars = GetServiceRegistrars(scanningType);

            foreach (var serviceRegistrar in serviceRegistrars)
            {
                serviceRegistrar.RegisterServices(builder);
            }
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            MiddlewareRegistrar.RegisterMiddlewares(app);
        }

        private static IEnumerable<IServiceRegistrar> GetServiceRegistrars(Type scanningType)
        {
            return scanningType.Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IServiceRegistrar)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IServiceRegistrar>();
        }
    }
}
