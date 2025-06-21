using Newtonsoft.Json;
using System.Net;

namespace LagRabbitMqManagerToolkit.Domains
{
    public readonly struct RabbitRequestResult
    {
        public RabbitRequestResult(HttpResponseMessage httpResponse)
        {
            HttpStatusCode = httpResponse.StatusCode;
            IsSucess = httpResponse.IsSuccessStatusCode;

            try
            {
                httpResponse.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Exception = ex;
            }
        }

        public readonly bool IsSucess;
        public readonly HttpStatusCode HttpStatusCode;
        public readonly Exception? Exception;

        public static implicit operator RabbitRequestResult(HttpResponseMessage httpResponse) => new(httpResponse);
    }

    public readonly struct RabbitRequestResult<T>
    {
        public RabbitRequestResult(HttpResponseMessage httpResponse)
        {
            HttpStatusCode = httpResponse.StatusCode;
            IsSucess = httpResponse.IsSuccessStatusCode;

            var content = httpResponse.Content.ReadAsStringAsync().Result;

            try
            {
                httpResponse.EnsureSuccessStatusCode();
                Result = JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {
                Exception = ex;
            }
        }

        public readonly T? Result;
        public readonly bool IsSucess;
        public readonly HttpStatusCode HttpStatusCode;
        public readonly Exception? Exception;

        public static implicit operator RabbitRequestResult<T>(HttpResponseMessage httpResponse) => new(httpResponse);
    }
}
