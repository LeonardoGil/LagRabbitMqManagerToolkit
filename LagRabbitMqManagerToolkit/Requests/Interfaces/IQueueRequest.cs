using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Requests.Interfaces
{
    public interface IQueueRequest
    {
        Task<IList<Queue>> ListAsync();
        
        Task<Queue?> GetAsync(string vHost, string queue);

        Task<IList<Message>> GetMessagesAsync(string vHost, string queue, int take = 200);
    }
}
