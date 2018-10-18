using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos.Queries;
namespace WebApplication1.Helpers
{
    public class Sorting<T>
    {
        public static IQueryable<T> Get(IQueryable<T> query,ISort sort)
        {
            sort.OrderBy = sort.OrderBy.ToLower();
            if (sort.OrderBy.Equals("desc"))
                return query.OrderByDescending(x => ReflectionProperty.Get(x,sort.SortBy).GetValue(x, null));
            else
                return query.OrderBy(x => ReflectionProperty.Get(x, sort.SortBy).GetValue(x, null));
        }
    }
}
