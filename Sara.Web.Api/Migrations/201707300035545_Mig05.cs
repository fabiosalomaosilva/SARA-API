namespace Sara.Web.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patologias", "Descricao", c => c.String(nullable: false, maxLength: 400));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patologias", "Descricao");
        }
    }
}
