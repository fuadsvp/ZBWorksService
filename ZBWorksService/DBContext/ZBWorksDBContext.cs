using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZBWorksService.Data_Models;
using System.Text;
using System.Threading.Tasks;

namespace ZBWorksService.DBContext
{
    public class ZBWorksDBContext : DbContext
    {
        private const string connectionStringName = "MS_TableConnectionString";

        public ZBWorksDBContext() : base(connectionStringName)
        {
            Database.CommandTimeout = 120;
        }
        public virtual DbSet<ZB_USERDETAILS> ZBUSERDETAILs { get; set; }
        public virtual DbSet<ZB_WORKS> ZBWORKs { get; set; }

    }
}