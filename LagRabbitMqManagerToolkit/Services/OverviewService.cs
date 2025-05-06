using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Extensions;
using LagRabbitMqManagerToolkit.Services.Interfaces;

namespace LagRabbitMqManagerToolkit.Services
{
    internal class OverviewService() : IOverviewService
    {
        public async Task GetAsync(RabbitSettings setting)
        {
            var baseUrl = new Uri(setting.Url);

            var url = new Uri(baseUrl, RabbitEndpoints.Overview);

            var token = RabbitRequestExtensions.BasicToken(setting);

            await RabbitRequestExtensions.Get<object>(url, token);
        }
    }
}
