using MediatR;

namespace Framework.EventBase.CommandHandlers
{
    public interface ITransactionalCommandHandlerMediatR<in TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse>
        where TCommand : IRequest<TResponse> where TResponse : ResponseCommand
    {
    }
}