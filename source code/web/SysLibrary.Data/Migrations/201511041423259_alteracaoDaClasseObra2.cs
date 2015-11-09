namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoDaClasseObra2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Obras", "DataDePublicacao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Obras", "DataDePublicacao", c => c.DateTime(nullable: false));
        }
    }
}
