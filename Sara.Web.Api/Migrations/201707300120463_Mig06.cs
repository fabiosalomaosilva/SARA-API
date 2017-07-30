namespace Sara.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig06 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acaos", "Area_Id", "dbo.Areas");
            DropForeignKey("dbo.Areas", "Patologia_Id", "dbo.Patologias");
            DropIndex("dbo.Acaos", new[] { "Area_Id" });
            DropIndex("dbo.Areas", new[] { "Patologia_Id" });
            RenameColumn(table: "dbo.Acaos", name: "Area_Id", newName: "AreaID");
            RenameColumn(table: "dbo.Areas", name: "Patologia_Id", newName: "PatologiaID");
            AlterColumn("dbo.Acaos", "AreaID", c => c.Int(nullable: false));
            AlterColumn("dbo.Areas", "PatologiaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Acaos", "AreaID");
            CreateIndex("dbo.Areas", "PatologiaID");
            AddForeignKey("dbo.Acaos", "AreaID", "dbo.Areas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Areas", "PatologiaID", "dbo.Patologias", "Id", cascadeDelete: true);
            DropColumn("dbo.Acaos", "IdArea");
            DropColumn("dbo.Areas", "IdPatologia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Areas", "IdPatologia", c => c.Int(nullable: false));
            AddColumn("dbo.Acaos", "IdArea", c => c.Int(nullable: false));
            DropForeignKey("dbo.Areas", "PatologiaID", "dbo.Patologias");
            DropForeignKey("dbo.Acaos", "AreaID", "dbo.Areas");
            DropIndex("dbo.Areas", new[] { "PatologiaID" });
            DropIndex("dbo.Acaos", new[] { "AreaID" });
            AlterColumn("dbo.Areas", "PatologiaID", c => c.Int());
            AlterColumn("dbo.Acaos", "AreaID", c => c.Int());
            RenameColumn(table: "dbo.Areas", name: "PatologiaID", newName: "Patologia_Id");
            RenameColumn(table: "dbo.Acaos", name: "AreaID", newName: "Area_Id");
            CreateIndex("dbo.Areas", "Patologia_Id");
            CreateIndex("dbo.Acaos", "Area_Id");
            AddForeignKey("dbo.Areas", "Patologia_Id", "dbo.Patologias", "Id");
            AddForeignKey("dbo.Acaos", "Area_Id", "dbo.Areas", "Id");
        }
    }
}
