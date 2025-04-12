using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Requests.Interfaces;

namespace LagRabbitMqManagerToolkit.Requests
{
    internal class QueueRequest(RabbitSettings _settings, RabbitRequest _request) : IQueueRequest
    {
        public async Task<Queue?> GetAsync(string vHost, string queue)
        {
            var endpoint = RabbitEndpoints.GetQueue(vHost, queue);
            
            var url = new Uri(new Uri(_settings.Url), endpoint);

            var token = _request.BasicToken(_settings);
            
            return await _request.Get<Queue>(url, token);
        }
    }
}
