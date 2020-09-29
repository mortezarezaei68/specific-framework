using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Framework.CQRS.CommandCustomize
{
    public interface IEventBus
    {
        Task<TResponse> Issue<TResponse>(IRequest<TResponse> command, CancellationToken cancellationToken = default) where TResponse : ResponseCommand;
    }
}