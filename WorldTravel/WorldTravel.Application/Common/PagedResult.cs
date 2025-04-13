namespace WorldTravel.Application.Common;

public class PagedResult<T>
{
    public PagedResult(IEnumerable<T> items, int totalCount, int size, int page)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        Size = size;
        From = (page - 1) * size + 1;
        To = From + size - 1;
        TotalPages = (int)Math.Ceiling((double)TotalCount / Size);
        HasPreviousPage = page > 1;
        HasNextPage = page < TotalPages;
    }
    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
    public int TotalPages { get; }
    public bool HasPreviousPage { get; }
    public bool HasNextPage { get; }
    public int? From { get; }
    public int? To { get; }

}
