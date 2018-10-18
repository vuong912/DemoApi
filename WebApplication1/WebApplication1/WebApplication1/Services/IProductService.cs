using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Dtos.Queries;
namespace WebApplication1.Services
{
    public interface IProductService
    {
        Task<Object> Get(ProductQuery query);
        Task<Product> Get(int id);
        Task Create(Product product);
        Task Update(int idx,Product product);
    }
}
