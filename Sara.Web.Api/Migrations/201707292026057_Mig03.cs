namespace Sara.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Recomendacao = c.Boolean(nullable: false),
                        IdPatologia = c.Int(nullable: false),
                        Patologia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patologias", t => t.Patologia_Id)
                .Index(t => t.Patologia_Id);
            
            CreateTable(
                "dbo.Patologias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        IdArea = c.Int(nullable: false),
                        Area_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.Area_Id)
                .Index(t => t.Area_Id);
            
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patologias", "Area_Id", "dbo.Areas");
            DropForeignKey("dbo.Acaos", "Patologia_Id", "dbo.Patologias");
            DropIndex("dbo.Patologias", new[] { "Area_Id" });
            DropIndex("dbo.Acaos", new[] { "Patologia_Id" });
            DropTable("dbo.Areas");
            DropTable("dbo.Patologias");
            DropTable("dbo.Acaos");
        }
    }
}
