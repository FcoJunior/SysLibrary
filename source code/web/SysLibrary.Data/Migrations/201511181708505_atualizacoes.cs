namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizacoes : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Locacoes", "DataDeDevolucao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locacoes", "DataDeDevolucao", c => c.DateTime());
        }
    }
}
