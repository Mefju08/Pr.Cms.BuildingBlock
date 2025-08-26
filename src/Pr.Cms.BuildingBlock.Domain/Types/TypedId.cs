namespace Pr.Cms.BuildingBlock.Domain.Types
{
    /// <summary>
    /// Abstrakcyjna klasa bazowa dla silnie typowanych identyfikatorów encji domenowych.
    /// Zapewnia bezpieczeństwo typów i walidację wartości GUID, zapobiegając pomyleniu różnych identyfikatorów.
    /// </summary>
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
