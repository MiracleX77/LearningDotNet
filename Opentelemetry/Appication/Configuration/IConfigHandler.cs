using MediatR;

namespace Roller.Appication.Configuration
{
    public interface IConfigHandler<in TConfig,TResult> : IRequestHandler<TConfig,TResult> where TConfig : IConfig<TResult>
    {
    }
}