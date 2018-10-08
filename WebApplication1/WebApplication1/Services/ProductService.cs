using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        DataContext db;
        public ProductService(DataContext db)
        {
            this.db = db;
        }

        public async Task Create(Product product)
        {
            await db.AddAsync(product);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(int idx,Product product)
        {
            product.Id = idx;
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }
    }
}
