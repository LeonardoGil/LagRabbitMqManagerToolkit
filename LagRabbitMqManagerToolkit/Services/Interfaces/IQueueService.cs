using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Requests;

namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    public interface IQueueService
    {
        Task<IList<Queue>> ListAsync();

        Task<Queue?> GetAsync(string vHost, string queue);
        
        Task<RabbitRequestResult<bool>> PutAsync(string vHost, string queue, bool autoDelete = false, bool durable = true);  

        Task<IList<Message>> GetMessagesAsync(string vHost, string queue, int take = 200);
    }
}
