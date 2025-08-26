using Pr.Cms.BuildingBlock.Abstractions.Time;

namespace Pr.Cms.BuildingBlock.Infrastructure.Time
{
    /// <summary>
    /// Implementacja dostawcy czasu systemowego skonfigurowana dla strefy czasowej Europa/Warszawa.
    /// Automatycznie konwertuje czas UTC na lokalny czas warszawski dla wszystkich operacji czasowych.
    /// </summary>
    internal sealed class SystemDateTimeProvider : IDateTimeProvider
    {
        private readonly TimeZoneInfo _timeZone;
        public SystemDateTimeProvider()
        {
            _timeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Warsaw");
        }
        public DateTimeOffset Now => TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, _timeZone);
        public DateOnly Today => DateOnly.FromDateTime(Now.Date);
    }
}