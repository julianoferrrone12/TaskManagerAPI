using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagerAPI.Helpers
{
    public class QueryObject
    {
        public string? Name { get; set; } = null;
        public string? Status { get; set; } = null;
        public string? SortBy { get; set; } = "CreatedDate";
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

    }
}