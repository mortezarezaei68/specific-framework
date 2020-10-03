using MediatR;

namespace Framework.CQRS.MediatRCommands
{
    public interface ITransactionalCommandHandlerMediatR<in TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse>
        where TCommand : IRequest<TResponse> where TResponse : ResponseCommand
    {
        
    }
}