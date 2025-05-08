using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Services;
using LagRabbitMqManagerToolkit.Services.Interfaces;
using Xunit;

namespace LagRabbitMqManagerToolkit.Tests.Integrations
{
    public class QueueServiceTest
    {
        private readonly IQueueService _queueRequest;
        private readonly IExchangeService _exchangeRequest;

        public QueueServiceTest()
        {
            var settings = RabbitSettings.Default();

            _queueRequest = new QueueService(settings);
            _exchangeRequest = new ExchangeService(settings);
        }

        [Fact]
        public async Task GetMessagesAsync_WithValidQueueName_ReturnsExpectedResultAsync()
        {
            var messages = await _queueRequest.GetMessagesAsync("/", "");

            Assert.NotEmpty(messages);
        }

        [Fact]
        public async Task GetAsync_WithValidQueueName_ReturnsExpectedResultAsync()
        {
            var queue = await _queueRequest.GetAsync("/", "");

            Assert.NotNull(queue);
        }

        [Fact]
        public async Task PublishAsync()
        {
            var properties = new Dictionary<string, string>()
            {
                { "message_id", Guid.NewGuid().ToString() }
            };

            var payload = "<teste></teste>";

            await _exchangeRequest.PublishAsync("/", "", properties, payload);
        }
    }
}
