public class PaginationResponseDTO<T> {
    public int Page { get; set; }
    public int PageSize { get; set; }
    public required int TotalPages { get; set; }
    public required int TotalRecords { get; set; }
    public required IEnumerable<T> Data { get; set; }
}