using Newtonsoft.Json;

namespace LagRabbitMqManagerToolkit.Domains;

public class Queue
{
    [JsonProperty("arguments")]
    public object Arguments { get; set; }

    [JsonProperty("auto_delete")]
    public bool AutoDelete { get; set; }

    [JsonProperty("consumer_capacity")]
    public string ConsumerCapacity { get; set; }

    [JsonProperty("consumer_utilisation")]
    public string ConsumerUtilisation { get; set; }

    [JsonProperty("consumers")]
    public int Consumers { get; set; }

    [JsonProperty("durable")]
    public bool Durable { get; set; }

    [JsonProperty("effective_policy_definition")]
    public object EffectivePolicyDefinition { get; set; }

    [JsonProperty("exclusive")]
    public bool Exclusive { get; set; }

    [JsonProperty("memory")]
    public int Memory { get; set; }

    [JsonProperty("message_bytes")]
    public long? MessageBytes { get; set; }

    [JsonProperty("message_bytes_paged_out")]
    public long? MessageBytesPagedOut { get; set; }

    [JsonProperty("message_bytes_persistent")]
    public long? MessageBytesPersistent { get; set; }

    [JsonProperty("message_bytes_ram")]
    public long? MessageBytesRam { get; set; }

    [JsonProperty("message_bytes_ready")]
    public long? MessageBytesReady { get; set; }

    [JsonProperty("message_bytes_unacknowledged")]
    public long? MessageBytesUnacknowledged { get; set; }

    [JsonProperty("messages")]
    public int Messages { get; set; }

    [JsonProperty("messages_details")]
    public Details MessagesDetails { get; set; }

    [JsonProperty("messages_paged_out")]
    public int MessagesPagedOut { get; set; }

    [JsonProperty("messages_persistent")]
    public int MessagesPersistent { get; set; }

    [JsonProperty("messages_ram")]
    public int MessagesRam { get; set; }

    [JsonProperty("messages_ready")]
    public int MessagesReady { get; set; }

    [JsonProperty("messages_ready_details")]
    public Details MessagesReadyDetails { get; set; }

    [JsonProperty("messages_ready_ram")]
    public int MessagesReadyRam { get; set; }

    [JsonProperty("messages_unacknowledged")]
    public int MessagesUnacknowledged { get; set; }

    [JsonProperty("messages_unacknowledged_details")]
    public Details MessagesUnacknowledgedDetails { get; set; }

    [JsonProperty("messages_unacknowledged_ram")]
    public int MessagesUnacknowledgedRam { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("node")]
    public string Node { get; set; }

    [JsonProperty("reductions")]
    public long Reductions { get; set; }

    [JsonProperty("reductions_details")]
    public Details ReductionsDetails { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("storage_version")]
    public int StorageVersion { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("vhost")]
    public string Vhost { get; set; }
}

public class Details
{
    [JsonProperty("rate")]
    public float Rate { get; set; }
}
