using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Test.Models
{
    public class ClientToken
    {
        public ClientToken (Client client)
        {
            this.Id = client.Id;
            this.Email = client.Email;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string clientToken { get; set; }
    }
}
