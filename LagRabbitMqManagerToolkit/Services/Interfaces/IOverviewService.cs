using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    public interface IOverviewService
    {
        Task<RabbitRequestResult<bool>> GetAsync(RabbitSettings? setting = null);
    }
}
