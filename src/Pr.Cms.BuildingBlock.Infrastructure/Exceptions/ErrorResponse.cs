namespace Pr.Cms.BuildingBlock.Infrastructure.Exceptions
{
    public record ErrorResponse(
         int StatusCode,
         string Title,
         string Detail,
         string Type,
         string TraceId
     );
}
