using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos.Queries;
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

        public async Task<Object> Get(ProductQuery query)
        {
            IQueryable<Product> productsQuery = ProcessQuery(db.Products, query);
            //-> Paging
            return new
            {
                Total = productsQuery.Count(),
                Result = await Paging<Product>.Get(productsQuery,query).ToListAsync()
            };
        }
        private IQueryable<Product> ProcessQuery(IQueryable<Product> products,ProductQuery query)
        {
            // Filter -> Sort 
            if (query.Name != null)
            {
                products = from x in products
                           where x.Name.Contains(query.Name)
                           select x;
            }
            if (query.Size != null)
            {
                products = from x in products
                           where query.Size.Contains(x.Size.ToString())
                           select x;
            }
            if (query.FromPrice != null)
                products = products.Where(x => query.FromPrice <= x.Price);
            if (query.ToPrice != null)
                products = products.Where(x => query.ToPrice >= x.Price);
            return Sorting<Product>.Get(products,query);
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
