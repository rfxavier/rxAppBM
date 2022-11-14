namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v48 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringUnidadeGerenciamentoRegionalId", c => c.Guid());
            AddColumn("dbo.BlueMeteringUnidadeGerenciamentoRegional", "BlueMeteringClienteId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringUnidadeGerenciamentoRegionalId");
            CreateIndex("dbo.BlueMeteringUnidadeGerenciamentoRegional", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringUnidadeGerenciamentoRegional", "BlueMeteringClienteId", "dbo.BlueMeteringCliente", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringUnidadeGerenciamentoRegionalId", "dbo.BlueMeteringUnidadeGerenciamentoRegional", "BlueMeteringUnidadeGerenciamentoRegionalId");
            DropColumn("dbo.BlueMeteringUnidadeNegocio", "IdUnidadeGerenciamentoRegional");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringUnidadeNegocio", "IdUnidadeGerenciamentoRegional", c => c.String(maxLength: 250, unicode: false));
            DropForeignKey("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringUnidadeGerenciamentoRegionalId", "dbo.BlueMeteringUnidadeGerenciamentoRegional");
            DropForeignKey("dbo.BlueMeteringUnidadeGerenciamentoRegional", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.BlueMeteringUnidadeGerenciamentoRegional", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringUnidadeNegocio", new[] { "BlueMeteringUnidadeGerenciamentoRegionalId" });
            DropColumn("dbo.BlueMeteringUnidadeGerenciamentoRegional", "BlueMeteringClienteId");
            DropColumn("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringUnidadeGerenciamentoRegionalId");
        }
    }
}
