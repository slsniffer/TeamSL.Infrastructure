using System;

namespace TeamSL.Infrastructure.Data
{
    public class RecordWithKey<T> : IEquatable<RecordWithKey<T>>
    {
        public virtual T Id { get; set; }

        public virtual bool Equals(RecordWithKey<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetRealType() != other.GetRealType())
                return false;

            if (!IsTransient() && !other.IsTransient() && Id.Equals(other.Id))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }

        public virtual bool IsTransient()
        {
            return Id.Equals(0);
        }

        public virtual Type GetRealType()
        {
            return GetType();
        }
    }
}