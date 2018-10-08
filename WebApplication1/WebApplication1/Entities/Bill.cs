using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Entities
{
    public class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserCreater { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
