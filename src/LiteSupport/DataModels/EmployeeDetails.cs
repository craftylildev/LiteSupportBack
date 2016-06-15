using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteSupport.DataModels
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
