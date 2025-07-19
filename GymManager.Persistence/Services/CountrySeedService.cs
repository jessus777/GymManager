using CsvHelper;
using EFCore.BulkExtensions;
using GymManager.Domain.Entities;
using GymManager.Persistence.Data;
using GymManager.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Text;
namespace GymManager.Persistence.Services
{
    public class CountrySeedService
        : ICountrySeedService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly CsvSettings _csvSettings;

        public CountrySeedService(ApplicationDbContext dbContext, IOptions<CsvSettings> csvOptions)
        {
            _dbContext = dbContext;
            _csvSettings = csvOptions.Value;
        }

        public async Task SeedCountriesAsync()
        {
            var countries = LoadCountriesFromCsv();

            if (countries == null || !countries.Any())
                return;

            var existing = await _dbContext.Countries.AsNoTracking().ToListAsync();

            if (existing.Count != 0)
            {
                await _dbContext.BulkDeleteAsync(existing);
            }

            await _dbContext.BulkInsertAsync(countries);
        }
        public List<Country> LoadCountriesFromCsv()
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, _csvSettings.CountriesFilePath);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("El archivo CSV no existe.", filePath);
            }

            using var reader = new StreamReader(filePath, Encoding.UTF8);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return [.. csv.GetRecords<Country>()];
        }
    }
}
