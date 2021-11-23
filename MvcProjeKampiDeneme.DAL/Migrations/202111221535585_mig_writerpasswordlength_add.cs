namespace MvcProjeKampiDeneme.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writerpasswordlength_add : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
        }
    }
}
