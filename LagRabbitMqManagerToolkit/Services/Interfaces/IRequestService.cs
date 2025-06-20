using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Services.Interfaces
{
    internal interface IRequestService
    {
        Task<HttpResponseMessage> GetAsync(RabbitSettings rabbitSettings, Uri url);
        
        Task Post(Uri url, string token, object body);
        Task<T?> Post<T>(Uri url, string token, object body) where T : class;
     
        Task<HttpResponseMessage> PutAsync(RabbitSettings rabbitSettings, Uri url, object body);
    }
}
