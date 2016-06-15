using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteSupport.Models
{
    public class Employee
    {
        
        public int EmployeeId { get; set; }
        public string FirstNameE { get; set; }
        public string LastNameE { get; set; }
        public string Username { get; set; }
        public string EmailE { get; set; }
        public string PhoneE { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
