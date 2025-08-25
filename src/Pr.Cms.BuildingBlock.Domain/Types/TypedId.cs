namespace Pr.Cms.BuildingBlock.Domain.Types
{
    public abstract record TypedId
    {
        public Guid Value { get; }

        protected TypedId(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            if (EqualityComparer<Guid>.Default.Equals(value, default!))
                throw new ArgumentException("ID value cannot be the default value.", nameof(value));

            Value = value;
        }

        public override string ToString()
            => Value.ToString();
    }
}
