using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    internal interface IRequestService
    {
        Task<HttpResponseMessage> GetAsync(RabbitSettings rabbitSettings, Uri url);
        Task<HttpResponseMessage> PostAsync(RabbitSettings rabbitSettings, Uri url, object body);
        Task<HttpResponseMessage> PutAsync(RabbitSettings rabbitSettings, Uri url, object body);
    }
}
