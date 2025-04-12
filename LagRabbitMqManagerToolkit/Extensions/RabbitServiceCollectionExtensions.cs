using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Requests.Interfaces;
using LagRabbitMqManagerToolkit.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace LagRabbitMqManagerToolkit.Extensions
{
    public static class RabbitServiceCollectionExtensions
    {
        public static IServiceCollection AddLagRabbitMqManagerToolkit(this IServiceCollection services, RabbitSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);
            
            services.AddScoped((provider) => settings);
            
            services.AddScoped<IQueueRequest, QueueRequest>();
            services.AddScoped<IOverviewRequest, OverviewRequest>();
            
            return services;
        }
    }
}
