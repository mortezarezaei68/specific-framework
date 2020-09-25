using System.Threading.Tasks;

namespace Framework.EF.Commands
{
    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}