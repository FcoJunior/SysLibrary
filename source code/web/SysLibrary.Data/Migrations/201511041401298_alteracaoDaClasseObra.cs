namespace SysLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracaoDaClasseObra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Obras", "CodigoISBN", c => c.String());
            AddColumn("dbo.Obras", "DataDePublicacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Obras", "Informacoes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Obras", "Informacoes");
            DropColumn("dbo.Obras", "DataDePublicacao");
            DropColumn("dbo.Obras", "CodigoISBN");
        }
    }
}
