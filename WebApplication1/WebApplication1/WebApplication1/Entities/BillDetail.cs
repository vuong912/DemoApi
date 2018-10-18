using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Entities
{
    public class BillDetail
    {
        public int IdBill { get; set; }
        public int IdProduct { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
}
