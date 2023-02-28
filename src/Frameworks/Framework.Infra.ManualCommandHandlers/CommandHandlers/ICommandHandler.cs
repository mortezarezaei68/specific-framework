using System.Threading.Tasks;

namespace Framework.Infra.ManualCommandHandlers.CommandHandlers
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}