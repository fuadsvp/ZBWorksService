using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZBWorksService.Data_Models
{
    [Table("ZB_USERDETAILS")]
    public class ZB_USERDETAILS
    {
        [Key]
        public string InternalEmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int Role { get; set; }
        public string Password { get; set; }
        public string Attribute { get; set; } ="";

    }
}