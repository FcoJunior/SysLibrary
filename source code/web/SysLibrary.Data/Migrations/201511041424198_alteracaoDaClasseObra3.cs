namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoDaClasseObra3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Obras", "AnoDePublicacao", c => c.Int(nullable: false));
            DropColumn("dbo.Obras", "DataDePublicacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Obras", "DataDePublicacao", c => c.DateTime());
            DropColumn("dbo.Obras", "AnoDePublicacao");
        }
    }
}
