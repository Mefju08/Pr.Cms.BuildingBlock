using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Pr.Cms.BuildingBlock.Infrastructure")]
namespace Pr.Cms.BuildingBlock.Abstractions.Time
{
    /// <summary>
    /// Statyczny zegar zapewniaj¹cy globalny dostêp do us³ugi czasu poprzez.
    /// Wymaga inicjalizacji z implementacj¹ IDateTimeProvider przed u¿yciem (automatyczna rejestracja).
    /// </summary>
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

        public static DateOnly Today => _provider.Today;
        public static DateTimeOffset Now => _provider.Now;

    }
}