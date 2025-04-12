using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Requests.Interfaces;

namespace LagRabbitMqManagerToolkit.Requests
{
    internal class OverviewRequest(RabbitRequest _request) : IOverviewRequest
    {
        public async Task Get(RabbitSettings setting)
        {
            var baseUrl = new Uri(setting.Url);

            var url = new Uri(baseUrl, RabbitEndpoints.Overview);

            var token = _request.BasicToken(setting.Username, setting.Password);

            await _request.Get<object>(url, token);
        }
    }
}
