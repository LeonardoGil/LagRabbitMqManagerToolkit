using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Requests.Interfaces
{
    public interface IQueueRequest
    {
        Task<IList<Queue>> ListAsync();
        
        Task<Queue?> GetAsync(string vHost, string queue);

        Task<IList<Message>> GetMessagesAsync(string vHost, string queue, int take = 200);

        Task PublishAsync(string vHost, string queue, Dictionary<string, string> properties, string payload, string encoding = "string");
    }
}
