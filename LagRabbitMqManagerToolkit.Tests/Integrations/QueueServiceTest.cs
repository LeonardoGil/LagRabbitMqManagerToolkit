using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Services;
using LagRabbitMqManagerToolkit.Services.Interfaces;

namespace LagRabbitMqManagerToolkit.Tests.Integrations
{
    public class QueueServiceTest
    {
        private readonly IQueueService _queueRequest;
        private readonly IExchangeService _exchangeRequest;

        public QueueServiceTest()
        {
            var settings = RabbitSettings.Default();
            var requestService = new RequestService();

            _queueRequest = new QueueService(requestService, settings);
            _exchangeRequest = new ExchangeService(requestService, settings);
        }
    }
}
