namespace Pr.Cms.BuildingBlock.Domain.Types
{
    public abstract class Entity : IEquatable<Entity>
    {
        public TypedId Id { get; protected set; }



        public override bool Equals(object? obj)
            => Equals(obj as Entity);

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (other is null || GetType() != other.GetType())
                return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
            => HashCode.Combine(GetType(), Id);

        public static bool operator ==(Entity? left, Entity? right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(Entity? left, Entity? right)
            => !(left == right);
    }
}
