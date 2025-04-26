using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Extensions;
using LagRabbitMqManagerToolkit.Requests.Interfaces;

namespace LagRabbitMqManagerToolkit.Requests
{
    internal class QueueRequest(RabbitSettings _settings) : IQueueRequest
    {
        public async Task<Queue?> GetAsync(string vHost, string queue)
        {
            ArgumentException.ThrowIfNullOrEmpty(vHost);
            ArgumentException.ThrowIfNullOrEmpty(queue);

            var endpoint = RabbitEndpoints.GetQueue(vHost, queue);

            var url = new Uri(new Uri(_settings.Url), endpoint);

            var token = RabbitRequestExtensions.BasicToken(_settings);

            return await RabbitRequestExtensions.Get<Queue>(url, token);
        }

        public async Task<IList<Message>> GetMessagesAsync(string vHost, string queue, int take = 200)
        {
            ArgumentException.ThrowIfNullOrEmpty(vHost);
            ArgumentException.ThrowIfNullOrEmpty(queue);

            var endpoint = RabbitEndpoints.GetQueueMessages(vHost, queue);

            var url = new Uri(new Uri(_settings.Url), endpoint);

            var body = new
            {
                ackmode = "ack_requeue_true",
                encoding = "auto",
                count = take
            };

            var token = RabbitRequestExtensions.BasicToken(_settings);

            return await RabbitRequestExtensions.Post<IList<Message>>(url, token, body) ?? [];
        }

        public async Task<IList<Queue>> ListAsync()
        {
            var endpoint = RabbitEndpoints.Queues;

            var url = new Uri(new Uri(_settings.Url), endpoint);

            var token = RabbitRequestExtensions.BasicToken(_settings);

            return await RabbitRequestExtensions.Get<List<Queue>>(url, token) ?? [];
        }

        public async Task PublishAsync(string vHost, string queue, Dictionary<string, string> properties, string payload, string encoding = "UTF-8")
        {
            var endpoint = RabbitEndpoints.PublishMessage(vHost, "amq.default");

            var url = new Uri(new Uri(_settings.Url), endpoint);

            var token = RabbitRequestExtensions.BasicToken(_settings);

            var body = new
            {
                properties,

                routing_key = queue,

                payload,

                payload_encoding = encoding
            };

            await RabbitRequestExtensions.Post(url, token, body);
        }
    }
}
