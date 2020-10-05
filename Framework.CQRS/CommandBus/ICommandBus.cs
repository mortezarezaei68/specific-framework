using System.Threading.Tasks;

namespace Framework.CQRS.CommandBus
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command);
    }
}