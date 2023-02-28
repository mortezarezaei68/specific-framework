using MediatR;

namespace Framework.Infra.MediatR
{
    public interface ITransactionalCommandHandlerMediatR<in TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse>
        where TCommand : IRequest<TResponse> where TResponse : class
    {
    }
}