using System.Threading.Tasks;

namespace Framework.EventBase.CommandHandlers
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}