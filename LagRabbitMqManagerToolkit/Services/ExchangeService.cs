using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Services.Interfaces;

namespace LagRabbitMqManagerToolkit.Services
{
    internal class ExchangeService(RabbitSettings _settings) : IExchangeService
    {
        public async Task PublishAsync(string vHost, string queue, Dictionary<string, string> properties, string payload, string exchange = "amq.default", string encoding = "UTF-8")
        {
            var endpoint = RabbitEndpoints.PublishMessage(vHost, exchange);

            var url = new Uri(new Uri(_settings.Url), endpoint);

            var token = RequestService.BasicToken(_settings);

            var body = new
            {
                properties,

                routing_key = queue,

                payload,

                payload_encoding = encoding
            };

            await RequestService.Post(url, token, body);
        }
    }
}
