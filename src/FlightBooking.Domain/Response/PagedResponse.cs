namespace FlightBooking.Domain.Response;

public class PagedResponse<T>
{
    public IEnumerable<T> Data { get; set; } = new List<T>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = 5;
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public bool HasNexPage => PageNumber < TotalPages;
    public bool HasPreviosPage => PageNumber > 1;

    public PagedResponse(){ }

    public PagedResponse(IEnumerable<T> data, int pageNumber, int pageSize, int totalItems)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems/(double)pageSize);
    }
}