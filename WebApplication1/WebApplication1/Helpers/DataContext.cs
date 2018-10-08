using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
namespace WebApplication1.Helpers
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> op) : base(op) { }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BillDetail>().HasKey(x => new { x.IdBill, x.IdProduct });
            builder.Entity<BillDetail>().HasOne<Bill>().WithMany(x => x.BillDetails).HasForeignKey(x => x.IdBill);
        }
    }
}
