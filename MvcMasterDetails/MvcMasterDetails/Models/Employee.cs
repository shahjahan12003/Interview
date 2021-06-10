using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMasterDetails.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
    }
}