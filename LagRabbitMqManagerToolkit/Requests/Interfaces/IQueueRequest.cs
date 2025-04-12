using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Requests.Interfaces
{
    public interface IQueueRequest
    {
        Task<Queue?> GetAsync(string vHost, string queue);
    }
}
