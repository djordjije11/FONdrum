using FONdrum.DataAccess;
using FONdrum.Seeding.Wines;
using Microsoft.Extensions.Logging;

namespace Cineast.Seeding
{
    public class Seeder
    {
        private readonly FONdrumContext _context;
        private readonly ILogger<Seeder> _logger;
        private readonly WineSeeder _wineSeeder;

        public Seeder(FONdrumContext context, ILogger<Seeder> logger, WineSeeder wineSeeder)
        {
            _context = context;
            _logger = logger;
            _wineSeeder = wineSeeder;
        }

        public bool Seed()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            try
            {
                _context.Database.BeginTransaction();
                SeedImpl();
                _context.SaveChanges();
                _context.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                _logger.LogCritical("Seeding entities failed!\nException: {ExceptionMessage} {ExceptionStackTrace}", 
                    ex.Message, ex.StackTrace);
                return false;
            }

            _logger.LogInformation("Seeding entities succeeded!");
            return true;
        }

        private void SeedImpl()
        {
            _wineSeeder.Seed();
        }
    }
}
