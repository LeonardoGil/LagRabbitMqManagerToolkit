using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Extensions;
using LagRabbitMqManagerToolkit.Requests;
using LagRabbitMqManagerToolkit.Services.Interfaces;
using Newtonsoft.Json;

namespace LagRabbitMqManagerToolkit.Services
{
    internal class QueueService(IRequestService requestService, 
                                RabbitSettings rabbitSettings) : IQueueService
    {
        public async Task<RabbitRequestResult<Queue?>> GetAsync(string vHost, string queue)
        {
            ArgumentException.ThrowIfNullOrEmpty(vHost);
            ArgumentException.ThrowIfNullOrEmpty(queue);

            var url = rabbitSettings.Url.CreateUri(RabbitEndpoints.GetQueue(vHost, queue));

            return await requestService.GetAsync(rabbitSettings, url);
        }

        public async Task<RabbitRequestResult> PutAsync(string vHost, string queue, bool autoDelete = false, bool durable = true)
        {
            ArgumentException.ThrowIfNullOrEmpty(vHost);
            ArgumentException.ThrowIfNullOrEmpty(queue);

            var url = rabbitSettings.Url.CreateUri(RabbitEndpoints.GetQueue(vHost, queue));

            var body = new
            {
                auto_delete = autoDelete,
                durable
            };

            return await requestService.PutAsync(rabbitSettings, url, body);
        }

        public async Task<RabbitRequestResult<IList<Message>>> GetMessagesAsync(string vHost, string queue, int take = 200)
        {
            ArgumentException.ThrowIfNullOrEmpty(vHost);
            ArgumentException.ThrowIfNullOrEmpty(queue);

            var url = rabbitSettings.Url.CreateUri(RabbitEndpoints.GetQueueMessages(vHost, queue));

            var body = new
            {
                ackmode = "ack_requeue_true",
                encoding = "auto",
                count = take
            };

            return await requestService.PostAsync(rabbitSettings, url, body);
        }

        public async Task<RabbitRequestResult<IList<Queue>>> ListAsync()
        {
            var url = rabbitSettings.Url.CreateUri(RabbitEndpoints.Queues);

            return await requestService.GetAsync(rabbitSettings, url);
        }
    }
}
