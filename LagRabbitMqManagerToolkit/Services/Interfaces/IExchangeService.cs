namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    internal interface IExchangeService
    {
        Task PublishAsync(string vHost, string queue, Dictionary<string, string> properties, string payload, string exchange = "amq.default", string encoding = "string");
    }
}
