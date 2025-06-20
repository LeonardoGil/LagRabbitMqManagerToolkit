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

            return services.AddServices(provider => settings);
        }

        public static IServiceCollection AddLagRabbitMqManagerToolkit(this IServiceCollection services, Func<IServiceProvider, RabbitSettings> settingsFunc)
        {
            ArgumentNullException.ThrowIfNull(settingsFunc);

            return services.AddServices(settingsFunc.Invoke);
        }

        private static IServiceCollection AddServices(this IServiceCollection services, Func<IServiceProvider, RabbitSettings> settingsFunc)
        {
            services.AddScoped(settingsFunc);

            services.AddScoped<IQueueService, QueueService>();
            services.AddScoped<IExchangeService, ExchangeService>();
            services.AddScoped<IOverviewService, OverviewService>();

            return services;
        }
    }
}
