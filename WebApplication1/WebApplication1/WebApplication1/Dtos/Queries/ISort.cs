using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dtos.Queries
{
    public interface ISort
    {
        string SortBy { get; set; }
        string OrderBy { get; set; }
    }
}
