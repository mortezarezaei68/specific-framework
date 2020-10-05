using System.Threading.Tasks;

namespace Framework.CQRS.CommandBus
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}