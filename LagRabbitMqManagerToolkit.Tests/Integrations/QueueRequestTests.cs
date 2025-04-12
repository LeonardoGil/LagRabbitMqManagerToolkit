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
    }
}
