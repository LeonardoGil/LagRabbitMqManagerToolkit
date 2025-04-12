using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Requests.Interfaces
{
    public interface IRabbitRequest
    {
        Task<T?> Get<T>(Uri url, string token) where T : class;
        Task<T?> Post<T>(Uri url, string token, object body) where T : class;

        string BasicToken(RabbitSettings settings);
        string BasicToken(string user, string password);
    }
}
