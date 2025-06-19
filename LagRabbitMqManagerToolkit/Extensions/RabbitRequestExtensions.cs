using LagRabbitMqManagerToolkit.Domains;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LagRabbitMqManagerToolkit.Extensions
{
    internal static class RabbitRequestExtensions
    {
        private static readonly HttpClient _httpClient = new();

        internal static async Task<T?> Get<T>(Uri url, string token) where T : class
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Get
            };

            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", token);

            var httpResult = await _httpClient.SendAsync(httpRequest);

            var result = await httpResult.Content.ReadAsStringAsync();

            if (!httpResult.IsSuccessStatusCode || result is null)
                throw new Exception(result);

            return JsonConvert.DeserializeObject<T>(result);
        }

        internal static async Task Post(Uri url, string token, object body)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            };

            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", token);

            var httpResult = await _httpClient.SendAsync(httpRequest);

            var result = await httpResult.Content.ReadAsStringAsync();

            if (!httpResult.IsSuccessStatusCode)
                throw new Exception(result);
        }

        internal static async Task<HttpResponseMessage> Put(RabbitSettings rabbitSettings, Uri url, object body)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Put,
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            };

            return await Request(httpRequest, rabbitSettings);
        }

        internal static async Task<T?> Post<T>(Uri url, string token, object body) where T : class
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = url,
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            };

            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", token);

            var httpResult = await _httpClient.SendAsync(httpRequest);

            var result = await httpResult.Content.ReadAsStringAsync();

            if (!httpResult.IsSuccessStatusCode)
                throw new Exception(result);

            return JsonConvert.DeserializeObject<T>(result);
        }

        internal static async Task<HttpResponseMessage> Request(HttpRequestMessage httpRequest, RabbitSettings rabbitSettings)
        {
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", BasicToken(rabbitSettings));

            return await _httpClient.SendAsync(httpRequest);
        }

        internal static string BasicToken(RabbitSettings settings) => BasicToken(settings.Username, settings.Password);
        internal static string BasicToken(string user, string password) => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{password}"));
    }
}
