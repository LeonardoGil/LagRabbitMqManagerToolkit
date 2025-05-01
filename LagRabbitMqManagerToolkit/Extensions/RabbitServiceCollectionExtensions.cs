using LagRabbitMqManagerToolkit.Domains;
using Microsoft.Extensions.DependencyInjection;
using LagRabbitMqManagerToolkit.Services;
using LagRabbitMqManagerToolkit.Services.Interfaces;

namespace LagRabbitMqManagerToolkit.Extensions
{
    public static class RabbitServiceCollectionExtensions
    {
        public static IServiceCollection AddLagRabbitMqManagerToolkit(this IServiceCollection services, RabbitSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);
            
            services.AddScoped((provider) => settings);
            
            services.AddScoped<IQueueService, QueueService>();
            services.AddScoped<IOverviewService, OverviewService>();
            
            return services;
        }
    }
}
