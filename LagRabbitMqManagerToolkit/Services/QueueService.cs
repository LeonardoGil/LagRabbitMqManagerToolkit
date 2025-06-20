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

            var response = await requestService.GetAsync(rabbitSettings, url);

            var content = response.Content.ReadAsStringAsync();

            try
            {
                response.EnsureSuccessStatusCode();

                var result = JsonConvert.DeserializeObject<Queue>(await content);

                return RabbitRequestResultExtensions.Sucess(result, await content);
            }
            catch (HttpRequestException ex)
            {
                return RabbitRequestResultExtensions.Fail<Queue?>(ex, await content);
            }
        }

        public async Task<RabbitRequestResult<bool>> PutAsync(string vHost, string queue, bool autoDelete = false, bool durable = true)
        {
            ArgumentException.ThrowIfNullOrEmpty(vHost);
            ArgumentException.ThrowIfNullOrEmpty(queue);

            var url = rabbitSettings.Url.CreateUri(RabbitEndpoints.GetQueue(vHost, queue));

            var body = new
            {
                auto_delete = autoDelete,
                
                durable
            };

            var response = await requestService.PutAsync(rabbitSettings, url, body);

            var content = response.Content.ReadAsStringAsync();

            try
            {
                response.EnsureSuccessStatusCode();

                return RabbitRequestResultExtensions.Sucess(true, await content);
            }
            catch (HttpRequestException ex)
            {
                return RabbitRequestResultExtensions.Fail<bool>(ex, await content);
            }
        }

        public async Task<IList<Message>> GetMessagesAsync(string vHost, string queue, int take = 200)
        {
            ArgumentException.ThrowIfNullOrEmpty(vHost);
            ArgumentException.ThrowIfNullOrEmpty(queue);

            var endpoint = RabbitEndpoints.GetQueueMessages(vHost, queue);

            var url = new Uri(new Uri(rabbitSettings.Url), endpoint);

            var body = new
            {
                ackmode = "ack_requeue_true",
                encoding = "auto",
                count = take
            };

            var token = requestService.BasicToken(rabbitSettings);

            return await requestService.Post<IList<Message>>(url, token, body) ?? [];
        }

        public async Task<IList<Queue>> ListAsync()
        {
            var endpoint = RabbitEndpoints.Queues;

            var url = new Uri(new Uri(rabbitSettings.Url), endpoint);

            var token = requestService.BasicToken(rabbitSettings);

            return await requestService.GetAsync<List<Queue>>(url, token) ?? [];
        }
    }
}
