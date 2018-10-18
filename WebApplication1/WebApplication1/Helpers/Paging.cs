using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos.Queries;
namespace WebApplication1.Helpers
{
    public class Paging<T>
    {
        public static IQueryable<T> Get(IQueryable<T> query,IPaging page)
        {
            return query.Skip(page.PageSize * (page.PageStep - 1)).Take(page.PageSize);
        }
    }
}
