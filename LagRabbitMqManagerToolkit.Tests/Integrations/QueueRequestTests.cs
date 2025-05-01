using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Requests;
using LagRabbitMqManagerToolkit.Requests.Interfaces;
using Xunit;

namespace LagRabbitMqManagerToolkit.Tests.Integrations
{
    public class QueueRequestTests
    {
        private readonly IQueueRequest _queueRequest;

        public QueueRequestTests()
        {
            var settings = RabbitSettings.Default();

            _queueRequest = new QueueRequest(settings);
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

            await _queueRequest.PublishAsync("/", "arrobateste", properties, payload);
        }
    }
}
