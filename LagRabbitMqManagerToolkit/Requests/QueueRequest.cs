using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Extensions;
using LagRabbitMqManagerToolkit.Requests.Interfaces;

namespace LagRabbitMqManagerToolkit.Requests
{
    internal class QueueRequest(RabbitSettings _settings) : IQueueRequest
    {
        public async Task<Queue?> GetAsync(string vHost, string queue)
        {
            var endpoint = RabbitEndpoints.GetQueue(vHost, queue);
            
            var url = new Uri(new Uri(_settings.Url), endpoint);

            var token = RabbitRequestExtensions.BasicToken(_settings);
            
            return await RabbitRequestExtensions.Get<Queue>(url, token);
        }
    }
}
