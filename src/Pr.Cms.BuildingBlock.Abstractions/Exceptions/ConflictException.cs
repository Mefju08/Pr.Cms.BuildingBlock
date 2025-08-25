namespace Pr.Cms.BuildingBlock.Abstractions.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(string resourceType, object resourceId)
            : base($"Conflict occurred with {resourceType} '{resourceId}'.")
        {
        }
    }
}
