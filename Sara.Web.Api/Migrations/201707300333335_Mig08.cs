namespace Sara.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig08 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acaos", "PatologiaID", "dbo.Patologias");
            DropIndex("dbo.Acaos", new[] { "PatologiaID" });
            RenameColumn(table: "dbo.Acaos", name: "PatologiaID", newName: "Patologia_Id");
            AlterColumn("dbo.Acaos", "Patologia_Id", c => c.Int());
            CreateIndex("dbo.Acaos", "Patologia_Id");
            AddForeignKey("dbo.Acaos", "Patologia_Id", "dbo.Patologias", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acaos", "Patologia_Id", "dbo.Patologias");
            DropIndex("dbo.Acaos", new[] { "Patologia_Id" });
            AlterColumn("dbo.Acaos", "Patologia_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Acaos", name: "Patologia_Id", newName: "PatologiaID");
            CreateIndex("dbo.Acaos", "PatologiaID");
            AddForeignKey("dbo.Acaos", "PatologiaID", "dbo.Patologias", "Id", cascadeDelete: true);
        }
    }
}
