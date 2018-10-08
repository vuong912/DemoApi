using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;

namespace WebApplication1.Services
{
    public class BillService : IBillService
    {
        private DataContext dataContext;
        public BillService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task Create(Bill bill)
        {
            await dataContext.AddAsync(bill);
            await dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bill>> Get()
        {
            return await dataContext.Bills.Include(x=>x.BillDetails).ToListAsync();
        }
    }
}
