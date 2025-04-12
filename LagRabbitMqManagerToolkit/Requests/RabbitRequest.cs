using LagRabbitMqManagerToolkit.Domains;
using LagRabbitMqManagerToolkit.Requests.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LagRabbitMqManagerToolkit.Requests
{
    internal class RabbitRequest : IRabbitRequest
    {
        private static HttpClient _httpClient = new();

        public async Task<T?> Get<T>(Uri url, string token) where T : class
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Get
            };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

            var httpResult = await _httpClient.SendAsync(httpRequest);

            var result = await httpResult.Content.ReadAsStringAsync();

            if (!httpResult.IsSuccessStatusCode || result is null)
                throw new Exception(result);

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<T?> Post<T>(Uri url, string token, object body) where T : class
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Post
            };

            var bodyJson = JsonConvert.SerializeObject(body);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

            httpRequest.Content = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            var httpResult = await _httpClient.SendAsync(httpRequest);

            var result = await httpResult.Content.ReadAsStringAsync();

            if (!httpResult.IsSuccessStatusCode)
                throw new Exception(result);

            return JsonConvert.DeserializeObject<T>(result);
        }

        public string BasicToken(RabbitSettings settings) => BasicToken(settings.Username, settings.Password);
        public string BasicToken(string user, string password) => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{password}"));
    }
}
