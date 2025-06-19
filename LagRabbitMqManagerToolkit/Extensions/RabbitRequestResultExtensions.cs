using LagRabbitMqManagerToolkit.Domains;

namespace LagRabbitMqManagerToolkit.Extensions
{
    internal static class RabbitRequestResultExtensions
    {
        internal static RabbitRequestResult<Obj> Sucess<Obj>(Obj obj, string content) => new(obj, content);
        internal static RabbitRequestResult<Obj> Fail<Obj>(Exception exception, string content) => new(exception, content);
    }
}
