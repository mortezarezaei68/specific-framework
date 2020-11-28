using Framework.Domain.EqualityHelpers;

namespace Framework.Domain
{
    public abstract class ValueObject
    {
        public override bool Equals(object obj)
        {
            return EqualsBuilder.ReflectionEquals(this, obj);
        }

        public override int GetHashCode()
        {
            return HashCodeBuilder.ReflectionHashCode(this);
        }
    }
}