using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Extensions;
using LagRabbitMqManagerToolkit.Services.Interfaces;

namespace LagRabbitMqManagerToolkit.Services
{
    internal class OverviewService(IRequestService requestService, RabbitSettings? rabbitSettings = null) : IOverviewService
    {
        public async Task<RabbitRequestResult<bool>> GetAsync(RabbitSettings? setting = null)
        {
            rabbitSettings ??= setting;

            ArgumentNullException.ThrowIfNull(rabbitSettings);

            var url = rabbitSettings.Url.CreateUri(RabbitEndpoints.Overview);

            var response = await requestService.GetAsync(rabbitSettings, url);

            var content = await response.Content.ReadAsStringAsync();

            try
            {
                response.EnsureSuccessStatusCode();

                return RabbitRequestResultExtensions.Sucess(true, content);
            }
            catch (HttpRequestException ex)
            {
                return RabbitRequestResultExtensions.Fail<bool>(ex, content);
            }
        }
    }
}
