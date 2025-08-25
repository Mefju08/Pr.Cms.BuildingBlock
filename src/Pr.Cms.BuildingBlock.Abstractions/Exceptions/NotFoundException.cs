namespace Pr.Cms.BuildingBlock.Abstractions.Exceptions
{
    public class NotFoundException : BaseException
    {
        public string ResourceType { get; }
        public object ResourceId { get; }

        public NotFoundException(string resourceType, object resourceId)
            : base($"{resourceType} with ID '{resourceId}' was not found.")
        {
            ResourceType = resourceType;
            ResourceId = resourceId;
        }
    }
}
