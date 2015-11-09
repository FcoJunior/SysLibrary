namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoDaClasseUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Endereco", c => c.String());
            AddColumn("dbo.Usuarios", "Bairro", c => c.String());
            AddColumn("dbo.Usuarios", "Estado", c => c.String());
            AddColumn("dbo.Usuarios", "Cidade", c => c.String());
            AddColumn("dbo.Usuarios", "CEP", c => c.String());
            AddColumn("dbo.Usuarios", "CPF", c => c.String());
            AddColumn("dbo.Usuarios", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Telefone");
            DropColumn("dbo.Usuarios", "CPF");
            DropColumn("dbo.Usuarios", "CEP");
            DropColumn("dbo.Usuarios", "Cidade");
            DropColumn("dbo.Usuarios", "Estado");
            DropColumn("dbo.Usuarios", "Bairro");
            DropColumn("dbo.Usuarios", "Endereco");
        }
    }
}
