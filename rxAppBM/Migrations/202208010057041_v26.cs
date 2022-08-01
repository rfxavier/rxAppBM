namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v26 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringUnidadeGerenciamentoRegional",
                c => new
                    {
                        BlueMeteringUnidadeGerenciamentoRegionalId = c.Guid(nullable: false),
                        IdUnidadeGerenciamentoRegional = c.String(maxLength: 250, unicode: false),
                        Nome = c.String(maxLength: 250, unicode: false),
                        Endereco = c.String(maxLength: 250, unicode: false),
                        latitude = c.Decimal(precision: 18, scale: 2),
                        longitude = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BlueMeteringUnidadeGerenciamentoRegionalId);
            
            CreateTable(
                "dbo.BlueMeteringUnidadeNegocio",
                c => new
                    {
                        BlueMeteringUnidadeNegocioId = c.Guid(nullable: false),
                        IdUnidadeNegocio = c.String(maxLength: 250, unicode: false),
                        Nome = c.String(maxLength: 250, unicode: false),
                        Endereco = c.String(maxLength: 250, unicode: false),
                        latitude = c.Decimal(precision: 18, scale: 2),
                        longitude = c.Decimal(precision: 18, scale: 2),
                        IdUnidadeGerenciamentoRegional = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.BlueMeteringUnidadeNegocioId);
            
            AddColumn("dbo.BlueMeteringLigacao", "IdUnidadeNegocio", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlueMeteringLigacao", "IdUnidadeNegocio");
            DropTable("dbo.BlueMeteringUnidadeNegocio");
            DropTable("dbo.BlueMeteringUnidadeGerenciamentoRegional");
        }
    }
}
