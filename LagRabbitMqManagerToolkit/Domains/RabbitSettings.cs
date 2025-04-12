namespace LagRabbitMqManagerToolkit.Domains;

public class RabbitSettings
{
    public required string Url { get; init; }

    public required string Username { get; init; }

    public required string Password { get; init; }

    public static RabbitSettings Default() => new()
    {
        Username = "guest",
        Password = "guest",
        Url = "http://localhost:15672/"
    };
}