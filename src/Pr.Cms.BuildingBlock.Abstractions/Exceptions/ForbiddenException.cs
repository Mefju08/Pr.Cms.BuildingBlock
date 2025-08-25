namespace Pr.Cms.BuildingBlock.Abstractions.Exceptions
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(string message = "Access denied. Insufficient permissions.")
            : base(message)
        {
        }
    }
}
