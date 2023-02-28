namespace Framework.Domain.Core
{
    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            EventId = Guid.NewGuid();
            EventPublishDateTime = DateTime.Now;
        }

        public Guid EventId { get; }

        public DateTime EventPublishDateTime { get; }
    }
}