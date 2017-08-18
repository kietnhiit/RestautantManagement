using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class eEmployee
    {
        public int EmployeeID { get; set; }
        
        public string Username { get; set; }

        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public bool Gender { get; set; }
        
        public string Address { get; set; }

        public decimal Phone { get; set; }

        public int TypeID { get; set; }
    }
}
