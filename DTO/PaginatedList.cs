public class PaginatedList<T>
{
    public IEnumerable<T> Data { get; private set; } = new List<T>();
    public int Page { get; private set; }
    public int PageSize { get; private set; }
    public int TotalRecords { get; private set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

    public PaginatedList(IQueryable<T> query, PaginationQueryParamsDTO paginationParams)
    {
        Page = paginationParams.Page < 1 ? 1 : paginationParams.Page;
        PageSize = paginationParams.PageSize < 1 ? 10 : paginationParams.PageSize;

        TotalRecords = query.Count();
        Data = query
            .Skip((Page - 1) * PageSize)
            .Take(PageSize)
            .ToList();
    }
}
