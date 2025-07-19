using GymManager.Application.Extensions;
using GymManager.Persistence.Data;
using GymManager.Persistence.Extension;
using GymManager.Persistence.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.Configure<CsvSettings>(builder.Configuration.GetSection("CsvSettings"));
var app = builder.Build();
using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ICountrySeedService>();
await seeder.SeedCountriesAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
