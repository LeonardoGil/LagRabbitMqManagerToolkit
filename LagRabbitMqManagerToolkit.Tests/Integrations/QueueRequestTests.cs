using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Services;
using LagRabbitMqManagerToolkit.Services.Interfaces;
using Xunit;

namespace LagRabbitMqManagerToolkit.Tests.Integrations
{
    public class QueueRequestTests
    {
        private readonly IQueueService _queueRequest;
        private readonly IExchangeService _exchangeRequest;

        public QueueRequestTests()
        {
            var settings = RabbitSettings.Default();

            _queueRequest = new QueueService(settings);
            _exchangeRequest = new ExchangeService(settings);
        }

        [Fact]
        public async Task GetAsync_WithValidQueueName_ReturnsExpectedResultAsync()
        {
            var queue = await _queueRequest.GetAsync("/", "error");

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

            await _exchangeRequest.PublishAsync("/", "teste", properties, payload);
        }
    }
}
