namespace WebAPI.Domain.Queries
{
    /// <summary>
    /// Holds query parameters get from URI
    /// </summary>
    public class QueryParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string SortBy { get; set; } = "Country";
        public bool OrderByDescending { get; set; } = false;
        public string FilterBy { get; set; } = "None";
    }
}
