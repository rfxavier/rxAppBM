namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v45 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringLigacao", "BlueMeteringConsumidorId", c => c.Guid());
            AddColumn("dbo.BlueMeteringConsumidor", "BlueMeteringClienteId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BlueMeteringConsumidor", "BlueMeteringClienteId");
            CreateIndex("dbo.BlueMeteringLigacao", "BlueMeteringConsumidorId");
            AddForeignKey("dbo.BlueMeteringConsumidor", "BlueMeteringClienteId", "dbo.BlueMeteringCliente", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringLigacao", "BlueMeteringConsumidorId", "dbo.BlueMeteringConsumidor", "BlueMeteringConsumidorId");
            DropColumn("dbo.BlueMeteringLigacao", "IdConsumidor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringLigacao", "IdConsumidor", c => c.String(maxLength: 250, unicode: false));
            DropForeignKey("dbo.BlueMeteringLigacao", "BlueMeteringConsumidorId", "dbo.BlueMeteringConsumidor");
            DropForeignKey("dbo.BlueMeteringConsumidor", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.BlueMeteringLigacao", new[] { "BlueMeteringConsumidorId" });
            DropIndex("dbo.BlueMeteringConsumidor", new[] { "BlueMeteringClienteId" });
            DropColumn("dbo.BlueMeteringConsumidor", "BlueMeteringClienteId");
            DropColumn("dbo.BlueMeteringLigacao", "BlueMeteringConsumidorId");
        }
    }
}
