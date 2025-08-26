namespace Pr.Cms.BuildingBlock.Application.Dtos
{
    public sealed record PagedResultDto<T>(
        IReadOnlyCollection<T> Items,
        int TotalCount,
        int PageNumber,
        int PageSize)

    {
        public int TotalPages => PageSize > 0 ? (int)Math.Ceiling((double)TotalCount / PageSize) : 0;
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
