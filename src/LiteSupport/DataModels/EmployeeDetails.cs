using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteSupport.DataModels
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string FirstNameE { get; set; }
        public string LastNameE { get; set; }
        public string Username { get; set; }
        public string EmailE { get; set; }
        public string PhoneE { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
