using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Queries
{
    /// <summary>
    /// Holds query parameters get from URI
    /// </summary>
    public class QueryParameters
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 5;
        public string sortBy { get; set; } = "Country";
        public bool orderByDescending { get; set; } = false;
        public string filterBy { get; set; } = "None";
    }
}
