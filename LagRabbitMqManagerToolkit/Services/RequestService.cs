using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LagRabbitMqManagerToolkit.Services
{
    internal class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient = new();

        public async Task<HttpResponseMessage> GetAsync(RabbitSettings rabbitSettings, Uri url)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Get
            };

            return await Request(httpRequest, rabbitSettings);
        }
        public async Task<HttpResponseMessage> PostAsync(RabbitSettings rabbitSettings, Uri url, object body)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            };

            return await Request(httpRequest, rabbitSettings);
        }
        public async Task<HttpResponseMessage> PutAsync(RabbitSettings rabbitSettings, Uri url, object body)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Put,
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            };

            return await Request(httpRequest, rabbitSettings);
        }

        private async Task<HttpResponseMessage> Request(HttpRequestMessage httpRequest, RabbitSettings rabbitSettings)
        {
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", BasicToken(rabbitSettings));

            return await _httpClient.SendAsync(httpRequest);
        }

        private static string BasicToken(RabbitSettings settings) => BasicToken(settings.Username, settings.Password);
        private static string BasicToken(string user, string password) => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{password}"));
    }
}
