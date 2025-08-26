namespace Pr.Cms.BuildingBlock.Infrastructure.Exceptions
{
    internal sealed record ErrorResponse(
         int StatusCode,
         string Title,
         string Detail);
}
