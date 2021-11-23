namespace MvcProjeKampiDeneme.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writeraddstatus_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterStatus");
        }
    }
}
