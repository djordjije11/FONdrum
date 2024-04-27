using FONdrum.DataAccess;
using FONdrum.Domain.Models;
using FONdrum.Seeding.Helper;
using FONdrum.Seeding.Models.Wines;

namespace FONdrum.Seeding.Wines
{
    public class WineSeeder
    {
        private const string WINE_STYLES_FILE_PATH = "D:\\MyDocs\\Programming Projects\\GitRepositories\\FONdrum\\server\\FONdrum\\FONdrum.Seeding\\Files\\Wines\\wineStyles.csv";
        private const string GRAPE_VARIETIES_FILE_PATH = "D:\\MyDocs\\Programming Projects\\GitRepositories\\FONdrum\\server\\FONdrum\\FONdrum.Seeding\\Files\\Wines\\grapeVarieties.csv";
        private const string WINE_FILE_PATH = "D:\\MyDocs\\Programming Projects\\GitRepositories\\FONdrum\\server\\FONdrum\\FONdrum.Seeding\\Files\\Wines\\wines.csv";

        private readonly FONdrumContext _context;

        public WineSeeder(FONdrumContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            Dictionary<string, WineStyle> wineStyleByNameMap = SeedWineStyles();
            Dictionary<string, GrapeVariety> grapeVarietyByNameMap = SeedGrapeVarieties();
            SeedWines(wineStyleByNameMap, grapeVarietyByNameMap);
        }

        private void SeedWines(Dictionary<string, WineStyle> wineStyles, Dictionary<string, GrapeVariety> grapeVarieties)
        {
            var csvDeserializer = new CsvDeserializer();
            List<WineCsv> winesCsv = csvDeserializer.Read<WineCsv>(WINE_FILE_PATH);
            foreach (WineCsv wineCsv in winesCsv)
            {
                WineStyle wineStyle = wineStyles[wineCsv.Style];
                GrapeVariety grapeVariety = grapeVarieties[wineCsv.Variety];
                Wine wine = new Wine(wineCsv.Name, wineCsv.Price, wineCsv.StockQuantity, wineStyle, grapeVariety, wineCsv.ImageUrl);
                _context.Wines.Add(wine);
            }
        }

        private Dictionary<string, WineStyle> SeedWineStyles()
        {
            var csvDeserializer = new CsvDeserializer();
            List<WineStyle> wineStyles = csvDeserializer.Read<WineStyle>(WINE_STYLES_FILE_PATH);
            _context.WineStyles.AddRange(wineStyles);
            Dictionary<string, WineStyle> wineStyleByNameMap = new Dictionary<string, WineStyle>(wineStyles.Count);
            foreach (var wineStyle in wineStyles)
            {
                wineStyleByNameMap.Add(wineStyle.Name, wineStyle);
            }
            return wineStyleByNameMap;
        }

        private Dictionary<string, GrapeVariety> SeedGrapeVarieties()
        {
            var csvDeserializer = new CsvDeserializer();
            List<GrapeVariety> grapeVarieties = csvDeserializer.Read<GrapeVariety>(GRAPE_VARIETIES_FILE_PATH);
            _context.GrapeVarieties.AddRange(grapeVarieties);
            Dictionary<string, GrapeVariety> grapeVarietyByNameMap = new Dictionary<string, GrapeVariety>(grapeVarieties.Count);
            foreach (var grapeVariety in grapeVarieties)
            {
                grapeVarietyByNameMap.Add(grapeVariety.Name, grapeVariety);
            }

            return grapeVarietyByNameMap;
        }
    }
}
