using System.Collections.Generic;
using Framework.EF.DomainEvents;

namespace Framework.EF.ContextFrameWork
{
    public abstract class AggregateRoot<TKey>:Entity<TKey>,IAggregateRoot
    {
    }
}