using System.Threading.Tasks;

namespace Framework.CQRS.DecoratorCommandBus
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}