using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Services.Interfaces;

namespace LagRabbitMqManagerToolkit.Services
{
    internal class OverviewService(IRequestService requestService, RabbitSettings? rabbitSettings = null) : IOverviewService
    {
        public async Task<RabbitRequestResult> GetAsync(RabbitSettings? setting = null)
        {
            rabbitSettings ??= setting;

            ArgumentNullException.ThrowIfNull(rabbitSettings);

            var url = rabbitSettings.Url.CreateUri(RabbitEndpoints.Overview);

            return await requestService.GetAsync(rabbitSettings, url);
        }
    }
}
