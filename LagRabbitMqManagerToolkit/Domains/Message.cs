using Newtonsoft.Json;

namespace LagRabbitMqManagerToolkit.Domains;

public class Message
{
    [JsonProperty("payload")]
    public string? Payload { get; set; }

    [JsonProperty("payload_encoding")]
    public string? PayloadEncoding { get; set; } 

    [JsonProperty("payload_bytes")]
    public int PayloadBytes { get; set; }

    [JsonProperty("redelivered")]
    public bool Redelivered { get; set; }

    [JsonProperty("exchange")]
    public string? Exchange { get; set; }

    [JsonProperty("routing_key")]
    public string? RoutingKey { get; set; }

    [JsonProperty("message_count")]
    public int MessageCount { get; set; }

    [JsonProperty("properties")]
    public Properties? Properties { get; set; }
}

public class Properties
{
    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("message_id")]
    public string? MessageId { get; set; }

    [JsonProperty("expiration")]
    public string? Expiration { get; set; }

    [JsonProperty("reply_to")]
    public string? ReplyTo { get; set; }

    [JsonProperty("correlation_id")]
    public string? CorrelationId { get; set; }

    [JsonProperty("delivery_mode")]
    public int DeliveryMode { get; set; }

    [JsonProperty("headers")]
    public Headers Headers { get; set; }

    [JsonProperty("content_type")]
    public string? ContentType { get; set; }
}
public class Headers
{
    [JsonProperty("$.diagnostics.hostdisplayname")]
    public string? DiagnosticsHostDisplayName { get; set; }

    [JsonProperty("$.diagnostics.hostid")]
    public string? DiagnosticsHostId { get; set; }

    [JsonProperty("$.diagnostics.originating.hostid")]
    public string? DiagnosticsOriginatingHostId { get; set; }

    [JsonProperty("TraceId")]
    public string? TraceId { get; set; }

    [JsonProperty("Tenant")]
    public string? Tenant { get; set; }
}
