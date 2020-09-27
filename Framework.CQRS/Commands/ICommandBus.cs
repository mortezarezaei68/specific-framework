using System.Threading.Tasks;

namespace Framework.EF.Commands
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command);
    }
}