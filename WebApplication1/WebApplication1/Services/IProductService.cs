using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
namespace WebApplication1.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
        Task Create(Product product);
        Task Update(int idx,Product product);
    }
}
