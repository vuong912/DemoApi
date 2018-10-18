using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Entities
{
    public class Account
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
    }
}
