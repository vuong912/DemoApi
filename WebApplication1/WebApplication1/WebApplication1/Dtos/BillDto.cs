using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dtos
{
    public class BillDto
    {
        public BillDto()
        {
            BillDetails = new HashSet<BillDetailDto>();
        }
        public DateTime Date { get; set; }
        public string UserCreater { get; set; }
        public virtual ICollection<BillDetailDto> BillDetails { get; set; }
    }
}
