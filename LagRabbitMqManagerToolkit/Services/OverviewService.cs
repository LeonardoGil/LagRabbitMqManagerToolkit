using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Extensions;
using LagRabbitMqManagerToolkit.Services.Interfaces;

namespace LagRabbitMqManagerToolkit.Services
{
    internal class OverviewService(RabbitSettings _setting) : IOverviewService
    {
        public async Task GetAsync()
        {
            var baseUrl = new Uri(_setting.Url);

            var url = new Uri(baseUrl, RabbitEndpoints.Overview);

            var token = RabbitRequestExtensions.BasicToken(_setting);

            await RabbitRequestExtensions.Get<object>(url, token);
        }
    }
}
