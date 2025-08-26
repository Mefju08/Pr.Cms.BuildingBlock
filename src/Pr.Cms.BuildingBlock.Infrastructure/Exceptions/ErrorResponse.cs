namespace Pr.Cms.BuildingBlock.Infrastructure.Exceptions
{
    public sealed record ErrorResponse(
         int StatusCode,
         string Title,
         string Detail,
         string Type,
         string TraceId
     );
}
