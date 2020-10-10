using System.Threading.Tasks;

namespace Framework.CQRS.DecoratorCommandBus
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command);
    }
}