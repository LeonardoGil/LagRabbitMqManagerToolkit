using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Extensions;
using LagRabbitMqManagerToolkit.Services.Interfaces;
using System.Runtime;

namespace LagRabbitMqManagerToolkit.Services
{
    internal class ExchangeService(RabbitSettings _settings) : IExchangeService
    {
        public async Task PublishAsync(string vHost, string queue, Dictionary<string, string> properties, string payload, string exchange = "amq.default", string encoding = "UTF-8")
        {
            var endpoint = RabbitEndpoints.PublishMessage(vHost, exchange);

            var url = new Uri(new Uri(_settings.Url), endpoint);

            var token = RabbitRequestExtensions.BasicToken(_settings);

            var body = new
            {
                properties,

                routing_key = queue,

                payload,

                payload_encoding = encoding
            };

            await RabbitRequestExtensions.Post(url, token, body);
        }
    }
}
