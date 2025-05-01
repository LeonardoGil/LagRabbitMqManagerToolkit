using LagRabbitMqManagerToolkit.Requests;

namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    public interface IQueueService
    {
        Task<IList<Queue>> ListAsync();

        Task<Queue?> GetAsync(string vHost, string queue);

        Task<IList<Message>> GetMessagesAsync(string vHost, string queue, int take = 200);
    }
}
