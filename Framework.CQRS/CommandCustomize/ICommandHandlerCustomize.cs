using MediatR;

namespace Framework.CQRS.CommandCustomize
{
    public interface ICommandHandlerCustomize<in TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse>
        where TCommand : IRequest<TResponse> where TResponse : ResponseCommand
    {
        
    }
}