namespace Pr.Cms.BuildingBlock.Core.Exceptions
{
    /// <summary>
    /// Wyjątek reprezentujący konflikt podczas operacji na zasobie o określonym typie i identyfikatorze.
    /// Automatycznie mapowany na kod HTTP 409 (Conflict).
    /// </summary>
    public class ConflictException : BaseException
    {
        public ConflictException(string resourceType, object resourceId)
            : base($"Conflict occurred with {resourceType} '{resourceId}'.")
        {
        }
    }
}
