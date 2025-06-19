namespace LagRabbitMqManagerToolkit.Domains
{
    public readonly struct RabbitRequestResult<T>
    {
        public RabbitRequestResult(T result, string? content = null)
        {
            Result = result;
            IsSucess = true;
            Content = content ?? string.Empty;
        }

        public RabbitRequestResult(Exception exception, string? content = null)
        {
            Exception = exception;
            IsSucess = false;
            Content = content ?? string.Empty;
        }

        public readonly string Content;
        public readonly T? Result;
        public readonly Exception? Exception;
        public readonly bool IsSucess;

        public static implicit operator RabbitRequestResult<T>(T obj) => new(obj);
        public static implicit operator RabbitRequestResult<T>(Exception ex) => new(ex);
    }
}
