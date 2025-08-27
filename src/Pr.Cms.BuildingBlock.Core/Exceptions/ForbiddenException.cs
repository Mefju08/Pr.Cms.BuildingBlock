namespace Pr.Cms.BuildingBlock.Core.Exceptions
{
    /// <summary>
    /// Wyjątek reprezentujący brak uprawnień dostępu do zasobu lub operacji.
    /// Automatycznie mapowany na kod HTTP 403 (Forbidden).
    /// </summary>
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(string message = "Access denied. Insufficient permissions.")
            : base(message)
        {
        }
    }
}
