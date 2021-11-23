namespace MvcProjeKampiDeneme.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_changeimagesize_add : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 100));
        }
    }
}
