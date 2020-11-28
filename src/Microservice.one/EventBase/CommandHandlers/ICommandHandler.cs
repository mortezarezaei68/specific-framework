using System.Threading.Tasks;

namespace EventBase.CommandHandlers
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}