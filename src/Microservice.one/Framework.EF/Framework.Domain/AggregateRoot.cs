using Framework.EF.ContextFrameWork;

namespace Framework.EF.Framework.Domain
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
    }
}