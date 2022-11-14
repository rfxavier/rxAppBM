namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "BlueMeteringLigacaoId", c => c.Guid());
            AddColumn("dbo.BlueMeteringLigacao", "BlueMeteringClienteId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BlueMeteringHidrometro", "BlueMeteringLigacaoId");
            CreateIndex("dbo.BlueMeteringLigacao", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringLigacao", "BlueMeteringClienteId", "dbo.BlueMeteringCliente", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringLigacaoId", "dbo.BlueMeteringLigacao", "BlueMeteringLigacaoId");
            DropColumn("dbo.BlueMeteringHidrometro", "IdLigacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "IdLigacao", c => c.String(maxLength: 250, unicode: false));
            DropForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringLigacaoId", "dbo.BlueMeteringLigacao");
            DropForeignKey("dbo.BlueMeteringLigacao", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.BlueMeteringLigacao", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringHidrometro", new[] { "BlueMeteringLigacaoId" });
            DropColumn("dbo.BlueMeteringLigacao", "BlueMeteringClienteId");
            DropColumn("dbo.BlueMeteringHidrometro", "BlueMeteringLigacaoId");
        }
    }
}
