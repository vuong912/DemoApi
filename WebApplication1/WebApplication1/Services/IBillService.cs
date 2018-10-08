using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
namespace WebApplication1.Services
{
    public interface IBillService
    {
        Task<IEnumerable<Bill>> Get();
        Task Create(Bill bill);
    }
}
