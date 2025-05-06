using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    public interface IOverviewService
    {
        Task GetAsync(RabbitSettings setting);
    }
}
