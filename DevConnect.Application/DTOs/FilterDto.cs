public class FilterDto
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;
    private int _pageSize = 6;
    public int PageSize { get => _pageSize; set => _pageSize = (value < MaxPageSize) ? value : MaxPageSize; }

    public string? sort { get; set; }
    public string? _search { get => _search; set => _search = value?.ToLower(); }

}