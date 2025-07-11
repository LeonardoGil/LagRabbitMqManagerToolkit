﻿namespace LagRabbitMqManagerToolkit.Domains
{
    public static class RabbitEndpoints
    {
        public const string Overview = "/api/overview";
        public const string Queues = "/api/queues";
        public const string DefaultVHost = "%2f";

        public static string Queue(string vhost, string queueName) => $"/api/queues/{Uri.EscapeDataString(vhost)}/{Uri.EscapeDataString(queueName)}";
        public static string QueueMessages(string vhost, string queueName) => $"/api/queues/{Uri.EscapeDataString(vhost)}/{Uri.EscapeDataString(queueName)}/get";
        public static string PublishMessage(string vhost, string queueName) => $"/api/exchanges/{Uri.EscapeDataString(vhost)}/{Uri.EscapeDataString(queueName)}/publish";

        internal static Uri CreateUri(this string url, string endpoint) => new(new Uri(url), endpoint);
    }
}
