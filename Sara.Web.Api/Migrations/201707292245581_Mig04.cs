namespace Sara.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig04 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acaos", "Patologia_Id", "dbo.Patologias");
            DropForeignKey("dbo.Patologias", "Area_Id", "dbo.Areas");
            DropIndex("dbo.Acaos", new[] { "Patologia_Id" });
            DropIndex("dbo.Patologias", new[] { "Area_Id" });
            AddColumn("dbo.Acaos", "IdArea", c => c.Int(nullable: false));
            AddColumn("dbo.Acaos", "Area_Id", c => c.Int());
            AddColumn("dbo.Areas", "IdPatologia", c => c.Int(nullable: false));
            AddColumn("dbo.Areas", "Patologia_Id", c => c.Int());
            AlterColumn("dbo.Acaos", "Nome", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Patologias", "Nome", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Areas", "Nome", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Acaos", "Area_Id");
            CreateIndex("dbo.Areas", "Patologia_Id");
            AddForeignKey("dbo.Acaos", "Area_Id", "dbo.Areas", "Id");
            AddForeignKey("dbo.Areas", "Patologia_Id", "dbo.Patologias", "Id");
            DropColumn("dbo.Acaos", "IdPatologia");
            DropColumn("dbo.Acaos", "Patologia_Id");
            DropColumn("dbo.Patologias", "IdArea");
            DropColumn("dbo.Patologias", "Area_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patologias", "Area_Id", c => c.Int());
            AddColumn("dbo.Patologias", "IdArea", c => c.Int(nullable: false));
            AddColumn("dbo.Acaos", "Patologia_Id", c => c.Int());
            AddColumn("dbo.Acaos", "IdPatologia", c => c.Int(nullable: false));
            DropForeignKey("dbo.Areas", "Patologia_Id", "dbo.Patologias");
            DropForeignKey("dbo.Acaos", "Area_Id", "dbo.Areas");
            DropIndex("dbo.Areas", new[] { "Patologia_Id" });
            DropIndex("dbo.Acaos", new[] { "Area_Id" });
            AlterColumn("dbo.Areas", "Nome", c => c.String());
            AlterColumn("dbo.Patologias", "Nome", c => c.String());
            AlterColumn("dbo.Acaos", "Nome", c => c.String());
            DropColumn("dbo.Areas", "Patologia_Id");
            DropColumn("dbo.Areas", "IdPatologia");
            DropColumn("dbo.Acaos", "Area_Id");
            DropColumn("dbo.Acaos", "IdArea");
            CreateIndex("dbo.Patologias", "Area_Id");
            CreateIndex("dbo.Acaos", "Patologia_Id");
            AddForeignKey("dbo.Patologias", "Area_Id", "dbo.Areas", "Id");
            AddForeignKey("dbo.Acaos", "Patologia_Id", "dbo.Patologias", "Id");
        }
    }
}
