using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Extensions;
using LagRabbitMqManagerToolkit.Requests.Interfaces;

namespace LagRabbitMqManagerToolkit.Requests
{
    internal class OverviewRequest(RabbitSettings _setting) : IOverviewRequest
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
