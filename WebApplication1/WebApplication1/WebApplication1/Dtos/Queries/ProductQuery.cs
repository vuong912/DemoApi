using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dtos.Queries
{
    public class ProductQuery : IPaging, ISort
    {
        public string Name { get; set; }
        public List<string> Size { get; set; }
        public int? FromPrice { get; set; }
        public int? ToPrice { get; set; }
        public string SortBy { get; set; } = "Id";
        public string OrderBy { get; set; } = "asc";
        public int PageSize { get; set; } = 10;
        public int PageStep { get; set; } = 1;
    }
}
