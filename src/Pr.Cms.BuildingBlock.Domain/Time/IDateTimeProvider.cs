namespace Pr.Cms.BuildingBlock.Domain.Time
{
    /// <summary>
    /// Kontrakt dla dostawcy czasu.
    /// </summary>
    public interface IDateTimeProvider
    {
        DateTimeOffset Now { get; }

        DateOnly Today { get; }
    }
}
