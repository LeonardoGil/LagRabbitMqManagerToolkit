using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    internal interface IExchangeService
    {
        Task<RabbitRequestResult> PublishAsync(string vHost, string queue, Dictionary<string, string> properties, string payload, string exchange = "amq.default", string encoding = "string");
    }
}
