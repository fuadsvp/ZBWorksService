using System;
using System.Collections.Generic;
using System.Text;

namespace ZBWorks.Domain_Models
{
    public enum EmployeeRole { Employee, Management, HR }

    public class ZBUserDetails
    {
        public string InternalEmployeeID { get; set; }
        public string EmployeeName { get; set; }      
        public int Role { get; set; }
        public string Password { get; set; }
        public string Attribute { get; set; } ="";       
        public List<ZBUserDetails> EmployeeList { get; set; }       
    }
}
