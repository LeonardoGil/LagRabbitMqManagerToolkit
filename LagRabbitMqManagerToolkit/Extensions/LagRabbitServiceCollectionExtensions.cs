using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Requests.Interfaces;
using LagRabbitMqManagerToolkit.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace LagRabbitMqManagerToolkit.Extensions
{
    public static class LagRabbitServiceCollectionExtensions
    {
        public static IServiceCollection AddLagRabbitMqManagerToolkit(this IServiceCollection services, RabbitSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);
            
            services.AddScoped((provider) => settings);
            
            services.AddScoped<IQueueRequest, QueueRequest>();
            services.AddScoped<IRabbitRequest, RabbitRequest>();
            
            return services;
        }
    }
}
