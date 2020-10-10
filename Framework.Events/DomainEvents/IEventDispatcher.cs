using System.Threading.Tasks;

namespace Framework.EF.DomainEvents
{
    public interface IEventDispatcher
    {
        Task Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent;
    }
}