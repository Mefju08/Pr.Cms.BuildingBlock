namespace Pr.Cms.BuildingBlock.Domain.Time;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }

    DateTime Now { get; }

    DateOnly Today { get; }
}