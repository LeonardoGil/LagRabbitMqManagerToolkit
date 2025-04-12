using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Requests.Interfaces
{
    public interface IOverviewRequest
    {
        Task Get(RabbitSettings setting);
    }
}
