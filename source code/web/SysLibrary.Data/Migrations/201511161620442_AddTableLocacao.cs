namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableLocacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locacoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UsuaroiId = c.Int(nullable: false),
                    ExemplarId = c.Int(nullable: false),
                    Status = c.Boolean(nullable: false, defaultValue: false),
                    DataDeLocacao = c.DateTime(nullable: false),
                    DataDeDevolucao = c.DateTime(nullable: false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exemplares", t => t.ExemplarId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuaroiId, cascadeDelete: true)
                .Index(t => t.ExemplarId)
                .Index(t => t.UsuaroiId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacoes", "ExemplarId", "dbo.Exemplares");
            DropForeignKey("dbo.Locacoes", "UsuaroiId", "dbo.Usuarios");
            DropIndex("dbo.Locacoes", new[] { "ExemplarId" });
            DropIndex("dbo.Locacoes", new[] { "UsuaroiId" });
            DropTable("dbo.Locacoes");
        }
    }
}
