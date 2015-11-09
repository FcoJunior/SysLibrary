namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Editoras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exemplares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ObraId = c.Int(nullable: false),
                        Patrimonio = c.String(),
                        DataDeCadastro = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Obras", t => t.ObraId, cascadeDelete: true)
                .Index(t => t.ObraId);
            
            CreateTable(
                "dbo.Obras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        DataDeCadastro = c.DateTime(nullable: false),
                        AutorId = c.Int(nullable: false),
                        EditoraId = c.Int(nullable: false),
                        GeneroId = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autores", t => t.AutorId, cascadeDelete: true)
                .ForeignKey("dbo.Editoras", t => t.EditoraId, cascadeDelete: true)
                .ForeignKey("dbo.Generos", t => t.GeneroId, cascadeDelete: true)
                .Index(t => t.AutorId)
                .Index(t => t.EditoraId)
                .Index(t => t.GeneroId);
            
            CreateTable(
                "dbo.Generos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Token = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exemplares", "ObraId", "dbo.Obras");
            DropForeignKey("dbo.Obras", "GeneroId", "dbo.Generos");
            DropForeignKey("dbo.Obras", "EditoraId", "dbo.Editoras");
            DropForeignKey("dbo.Obras", "AutorId", "dbo.Autores");
            DropIndex("dbo.Obras", new[] { "GeneroId" });
            DropIndex("dbo.Obras", new[] { "EditoraId" });
            DropIndex("dbo.Obras", new[] { "AutorId" });
            DropIndex("dbo.Exemplares", new[] { "ObraId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Generos");
            DropTable("dbo.Obras");
            DropTable("dbo.Exemplares");
            DropTable("dbo.Editoras");
            DropTable("dbo.Autores");
        }
    }
}
