using Cineast.Seeding;

namespace FONdrum.API.Seeding
{
    public class SeederFactory
    {
        private const string SEEDING_SECTION = "Seeding";
        private const string SEEDING_SHOULD_SEED_FIELD = "SeedData";

        public static bool Handle(WebApplication app)
        {
            if (IsSeedingSet(app.Configuration))
            {
                var scopedFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
                using (var scope = scopedFactory.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
                    return seeder.Seed();
                }
            }

            return false;
        }

        public static bool IsSeedingSet(IConfiguration appConfig)
        {
            return appConfig.GetSection(SEEDING_SECTION).GetValue<bool>(SEEDING_SHOULD_SEED_FIELD);
        }
    }
}
