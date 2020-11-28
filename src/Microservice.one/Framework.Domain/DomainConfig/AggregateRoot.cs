namespace Framework.Domain.DomainConfig
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
    }
}