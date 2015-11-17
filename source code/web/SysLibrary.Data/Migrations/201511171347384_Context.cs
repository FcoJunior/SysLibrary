namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Context : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locacoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        ExemplarId = c.Int(nullable: false),
                        DataDeLocacao = c.DateTime(nullable: false),
                        DataDeDevolucao = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exemplares", t => t.ExemplarId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.ExemplarId)
                .Index(t => t.UsuarioId);
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
