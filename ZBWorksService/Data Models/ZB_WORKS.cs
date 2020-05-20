using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ZBWorksService.Data_Models
{
    [Table("ZB_WORKS")]

    public class ZB_WORKS
    {
        [Key]
        public string InternalZBWorksId { get; set; }
        public string InternalEmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string TaskName { get; set; }
        public long TaskDate { get; set; }
        public int TaskDuration { get; set; }
        public string Attribute { get; set; } ="";

    }
}