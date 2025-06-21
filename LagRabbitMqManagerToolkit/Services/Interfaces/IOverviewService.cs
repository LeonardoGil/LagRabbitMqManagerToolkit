using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    public interface IOverviewService
    {
        Task<RabbitRequestResult> GetAsync(RabbitSettings? setting = null);
    }
}
