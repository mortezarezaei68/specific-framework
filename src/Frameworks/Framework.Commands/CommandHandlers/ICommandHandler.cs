using System.Threading.Tasks;

namespace Framework.Commands.CommandHandlers
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}