namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoDaClasseObra4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Obras", "AnoDePublicacao", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Obras", "AnoDePublicacao", c => c.Int(nullable: false));
        }
    }
}
