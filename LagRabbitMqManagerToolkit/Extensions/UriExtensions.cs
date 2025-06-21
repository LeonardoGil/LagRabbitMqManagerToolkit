using System.Web;

namespace LagRabbitMqManagerToolkit.Extensions;

internal static class UriExtensions
{
    internal static Uri AddQueyParams(this Uri baseUri, Dictionary<string, string> parameters)
    {
        if (parameters.Count == 0)
            return baseUri;

        var builder = new UriBuilder(baseUri);

        var query = HttpUtility.ParseQueryString(builder.Query);

        foreach (var param in parameters)
            query[param.Key] = param.Value;
        
        builder.Query = query.ToString();
        
        return builder.Uri;
    }
}
