using FONdrum.DataAccess;
using FONdrum.Domain.Models;

namespace FONdrum.Seeding.Wines
{
    public class WineSeeder
    {
        private FONdrumContext _context;
        private Random _random = new();

        public WineSeeder(FONdrumContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            List<WineStyle> wineStyles = SeedWineStyles();
            List<GrapeVariety> grapeVarieties = SeedGrapeVarieties();
            SeedWines(wineStyles, grapeVarieties);
        }

        private void SeedWines(List<WineStyle> wineStyles, List<GrapeVariety> grapeVarieties)
        {
            for (int i = 1; i <= 30; i++)
            {
                SeedWine(wineStyles, grapeVarieties, i);
            }
        }

        private void SeedWine(List<WineStyle> wineStyles, List<GrapeVariety> grapeVarieties, int counter)
        {
            _context.Wines.Add(new Wine($"Ime {counter}", _random.NextDouble() * 10000, _random.Next(200),
                wineStyles[_random.Next(wineStyles.Count)], grapeVarieties[_random.Next(grapeVarieties.Count)]));
        }

        private List<WineStyle> SeedWineStyles()
        {
            List<WineStyle> wineStyles = [
                new WineStyle("Penusavo"),
                new WineStyle("Belo"),
                new WineStyle("Crveno"),
                new WineStyle("Roze"),
                new WineStyle("Dezertno")
                ];
            _context.WineStyles.AddRange(wineStyles);
            return wineStyles;
        }

        private List<GrapeVariety> SeedGrapeVarieties()
        {
            List<GrapeVariety> grapeVarieties = [
                new GrapeVariety("Sovinjon"),
                new GrapeVariety("Prokupac"),
                new GrapeVariety("Tamjanika"),
                new GrapeVariety("Sardone"),
                new GrapeVariety("Vranac")
                ];
            _context.GrapeVarieties.AddRange(grapeVarieties);
            return grapeVarieties;
        }
    }
}
