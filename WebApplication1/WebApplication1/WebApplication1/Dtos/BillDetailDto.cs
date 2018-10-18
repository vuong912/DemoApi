using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dtos
{
    public class BillDetailDto
    {
        public int IdProduct { get; set; }
        public int IdBill { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
}
