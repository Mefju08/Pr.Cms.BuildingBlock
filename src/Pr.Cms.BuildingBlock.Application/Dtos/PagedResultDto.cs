namespace Pr.Cms.BuildingBlock.Application.Dtos
{
    /// <summary>
    /// Reprezentuje stronicowane wyniki zapytania zawierające kolekcję danych i dane paginacji.
    /// Automatycznie oblicza całkowitą liczbę stron na podstawie rozmiaru strony i liczby elementów.
    /// </summary>
    public sealed record PagedResultDto<T>(
        IReadOnlyCollection<T> Data,
        int Total,
        int PageNumber,
        int PageSize)

    {
        public int TotalPages => PageSize > 0 ? (int)Math.Ceiling((double)Total / PageSize) : 0;
    }
}
