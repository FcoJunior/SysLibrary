namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemaneColumnLocacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locacoes", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            DropColumn("dbo.Locacoes", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locacoes", "Status", c => c.Boolean(nullable: false, defaultValue: false));
            DropColumn("dbo.Locacoes", "Ativo");
        }
    }
}
