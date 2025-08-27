namespace Pr.Cms.BuildingBlock.Core.Time
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
