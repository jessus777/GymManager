using CsvHelper;
using GymManager.Domain.Entities;
using System.Globalization;

namespace GymManager.Persistence.Repositories
{
    public static class CountrySeeder
    {
        public static List<Country> LoadCountriesFromCsv()
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "Resources", "countries.csv");
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified CSV file does not exist.", filePath);
            }
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Country>().ToList();
            return records;
        }
    }
}
