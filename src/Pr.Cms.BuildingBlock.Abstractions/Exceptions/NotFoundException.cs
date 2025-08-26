namespace Pr.Cms.BuildingBlock.Abstractions.Exceptions
{
    /// <summary>
    /// Wyjątek reprezentujący sytuację, gdy żądany zasób o określonym typie i identyfikatorze nie został znaleziony.
    /// Automatycznie mapowany na kod HTTP 404 (Not Found).
    /// </summary>
    public class NotFoundException : BaseException
    {
        public NotFoundException(string resourceType, object resourceId)
            : base($"{resourceType} with ID '{resourceId}' was not found.")
        {
        }
    }
}
