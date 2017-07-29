namespace Sara.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NomeCompleto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NomeCompleto");
        }
    }
}
