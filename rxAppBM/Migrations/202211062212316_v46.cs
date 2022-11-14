namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v46 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringConsumidor", "BlueMeteringConsumidorTipoId", c => c.Guid());
            AddColumn("dbo.BlueMeteringConsumidorTipo", "BlueMeteringClienteId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BlueMeteringConsumidor", "BlueMeteringConsumidorTipoId");
            CreateIndex("dbo.BlueMeteringConsumidorTipo", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringConsumidorTipo", "BlueMeteringClienteId", "dbo.BlueMeteringCliente", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringConsumidor", "BlueMeteringConsumidorTipoId", "dbo.BlueMeteringConsumidorTipo", "BlueMeteringConsumidorTipoId");
            DropColumn("dbo.BlueMeteringConsumidor", "IdConsumidorTipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringConsumidor", "IdConsumidorTipo", c => c.String(maxLength: 250, unicode: false));
            DropForeignKey("dbo.BlueMeteringConsumidor", "BlueMeteringConsumidorTipoId", "dbo.BlueMeteringConsumidorTipo");
            DropForeignKey("dbo.BlueMeteringConsumidorTipo", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.BlueMeteringConsumidorTipo", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringConsumidor", new[] { "BlueMeteringConsumidorTipoId" });
            DropColumn("dbo.BlueMeteringConsumidorTipo", "BlueMeteringClienteId");
            DropColumn("dbo.BlueMeteringConsumidor", "BlueMeteringConsumidorTipoId");
        }
    }
}
