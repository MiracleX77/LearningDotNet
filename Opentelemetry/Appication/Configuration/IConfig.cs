using MediatR;

namespace Roller.Appication.Configuration
{
    public interface IConfig<out TResult> : IRequest<TResult>
    {
    }
}