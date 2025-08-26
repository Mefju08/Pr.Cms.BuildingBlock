using Pr.Cms.BuildingBlock.Domain.Time;

namespace Pr.Cms.BuildingBlock.Infrastructure.Time;
public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime Now => DateTime.Now;
    public DateOnly Today => DateOnly.FromDateTime(DateTime.Today);

}