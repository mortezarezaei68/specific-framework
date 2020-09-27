using System.Collections.Generic;

namespace Framework.EF.ContextFrameWork
{
    public abstract class AggregateRoot<TKey>:Entity<TKey>,IAggregateRoot
    {
    }
}