namespace ZBWorksService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZB_USERDETAILS",
                c => new
                    {
                        InternalEmployeeID = c.String(nullable: false, maxLength: 128),
                        EmployeeName = c.String(),
                        Role = c.Int(nullable: false),
                        Password = c.String(),
                        Attribute = c.String(),
                    })
                .PrimaryKey(t => t.InternalEmployeeID);
            
            CreateTable(
                "dbo.ZB_WORKS",
                c => new
                    {
                        InternalZBWorksId = c.String(nullable: false, maxLength: 128),
                        InternalEmployeeID = c.String(),
                        EmployeeName = c.String(),
                        TaskName = c.String(),
                        TaskDate = c.Long(nullable: false),
                        TaskDuration = c.Int(nullable: false),
                        Attribute = c.String(),
                    })
                .PrimaryKey(t => t.InternalZBWorksId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZB_WORKS");
            DropTable("dbo.ZB_USERDETAILS");
        }
    }
}
