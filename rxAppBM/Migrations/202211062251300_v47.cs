namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v47 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringLigacao", "BlueMeteringUnidadeNegocioId", c => c.Guid());
            AddColumn("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringClienteId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BlueMeteringLigacao", "BlueMeteringUnidadeNegocioId");
            CreateIndex("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringClienteId", "dbo.BlueMeteringCliente", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringLigacao", "BlueMeteringUnidadeNegocioId", "dbo.BlueMeteringUnidadeNegocio", "BlueMeteringUnidadeNegocioId");
            DropColumn("dbo.BlueMeteringLigacao", "IdUnidadeNegocio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringLigacao", "IdUnidadeNegocio", c => c.String(maxLength: 250, unicode: false));
            DropForeignKey("dbo.BlueMeteringLigacao", "BlueMeteringUnidadeNegocioId", "dbo.BlueMeteringUnidadeNegocio");
            DropForeignKey("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.BlueMeteringUnidadeNegocio", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringLigacao", new[] { "BlueMeteringUnidadeNegocioId" });
            DropColumn("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringClienteId");
            DropColumn("dbo.BlueMeteringLigacao", "BlueMeteringUnidadeNegocioId");
        }
    }
}
