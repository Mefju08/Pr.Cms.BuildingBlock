using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Pr.Cms.BuildingBlock.Infrastructure")]
namespace Pr.Cms.BuildingBlock.Domain.Time;

public static class Clock
{
    private static IDateTimeProvider _provider;
    private static readonly object _lock = new();
    public static IDateTimeProvider Provider
    {
        get
        {
            if (_provider is null)
                throw new InvalidOperationException("SystemClock has not been initialized. Call Initialize method first.");
            return _provider;
        }
    }

    internal static void Initialize(IDateTimeProvider dateTimeProvider)
    {
        ArgumentNullException.ThrowIfNull(dateTimeProvider);
        lock (_lock)
        {
            if (_provider is not null)
                throw new InvalidOperationException("SystemClock has already been initialized.");

            _provider = dateTimeProvider;
        }
    }


    public static DateTime UtcNow => _provider.UtcNow;
    public static DateTime Now => _provider.Now;
    public static DateOnly Today => _provider.Today;

}