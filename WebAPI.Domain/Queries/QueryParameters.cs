using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Queries
{
    /// <summary>
    /// Holds query parameters get from URI
    /// </summary>
    public class QueryParameters
    {
        [Range(int.MinValue, int.MaxValue)]
        public int PageNumber { get; set; } = 1;
        [Range(int.MinValue, int.MaxValue)]
        public int PageSize { get; set; } = 5;
        [StringLength(50)]
        public string SortBy { get; set; } = "Country";
        public bool OrderByDescending { get; set; } = false;
        [StringLength(50)]
        public string FilterBy { get; set; } = "None";
    }
}
