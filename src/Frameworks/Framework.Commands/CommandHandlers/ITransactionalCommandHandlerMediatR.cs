using MediatR;

namespace Framework.Commands.CommandHandlers
{
    public interface ITransactionalCommandHandlerMediatR<in TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse>
        where TCommand : IRequest<TResponse> where TResponse : ResponseCommand
    {
    }
}