using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dtos.Queries
{
    public interface IPaging
    {
        int PageSize { get; set; }
        int PageStep { get; set; }
    }
}
