using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Test.Models
{
    public class AdminToken
    {
        public AdminToken (Admin admin)
        {
            this.Id = admin.Id;
            this.Email = admin.Email;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
