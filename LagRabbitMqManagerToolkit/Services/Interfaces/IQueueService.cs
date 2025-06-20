using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Requests;

namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    public interface IQueueService
    {
        Task<RabbitRequestResult<IList<Queue>>> ListAsync();

        Task<RabbitRequestResult<Queue?>> GetAsync(string vHost, string queue);
        
        Task<RabbitRequestResult> PutAsync(string vHost, string queue, bool autoDelete = false, bool durable = true);  

        Task<RabbitRequestResult<IList<Message>>> GetMessagesAsync(string vHost, string queue, int take = 200);
    }
}
