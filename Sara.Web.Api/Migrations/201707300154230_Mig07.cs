namespace Sara.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig07 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acaos", "PatologiaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Acaos", "PatologiaID");
            AddForeignKey("dbo.Acaos", "PatologiaID", "dbo.Patologias", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acaos", "PatologiaID", "dbo.Patologias");
            DropIndex("dbo.Acaos", new[] { "PatologiaID" });
            DropColumn("dbo.Acaos", "PatologiaID");
        }
    }
}
