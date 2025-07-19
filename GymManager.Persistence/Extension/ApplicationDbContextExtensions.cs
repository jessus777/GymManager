using GymManager.Application.Interfaces.Persistence;
using GymManager.Domain.Entities;
using GymManager.Persistence.Database;
using GymManager.Persistence.Repositories;
using GymManager.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymManager.Persistence.Extension
{
    public static class ApplicationDbContextExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ICountrySeedService, CountrySeedService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();

            return services;
        }
    }
}
