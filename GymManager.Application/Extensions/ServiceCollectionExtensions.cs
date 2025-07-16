using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            // Example: services.AddScoped<IMyService, MyService>();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(config => {
                //services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
                config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
            return services;
        }
    }
}
