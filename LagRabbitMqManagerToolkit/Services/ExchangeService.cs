using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Services.Interfaces;

namespace LagRabbitMqManagerToolkit.Services
{
    internal class ExchangeService(IRequestService requestService, RabbitSettings rabbitSettings) : IExchangeService
    {
        public async Task<RabbitRequestResult> PublishAsync(string vHost, string queue, Dictionary<string, string> properties, string payload, string exchange = "amq.default", string encoding = "UTF-8")
        {
            var url = rabbitSettings.Url.CreateUri(RabbitEndpoints.PublishMessage(vHost, exchange));

            var body = new
            {
                properties,
                routing_key = queue,
                payload,
                payload_encoding = encoding
            };

            return await requestService.PostAsync(rabbitSettings, url, body);
        }
    }
}
