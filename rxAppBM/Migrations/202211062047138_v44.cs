namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v44 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "BlueMeteringValvulaCorteId", c => c.Guid());
            AddColumn("dbo.BlueMeteringValvulaCorte", "BlueMeteringClienteId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BlueMeteringHidrometro", "BlueMeteringValvulaCorteId");
            CreateIndex("dbo.BlueMeteringValvulaCorte", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringValvulaCorte", "BlueMeteringClienteId", "dbo.BlueMeteringCliente", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringValvulaCorteId", "dbo.BlueMeteringValvulaCorte", "BlueMeteringValvulaCorteId");
            DropColumn("dbo.BlueMeteringHidrometro", "IdValvulaCorte");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "IdValvulaCorte", c => c.String(maxLength: 250, unicode: false));
            DropForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringValvulaCorteId", "dbo.BlueMeteringValvulaCorte");
            DropForeignKey("dbo.BlueMeteringValvulaCorte", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.BlueMeteringValvulaCorte", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringHidrometro", new[] { "BlueMeteringValvulaCorteId" });
            DropColumn("dbo.BlueMeteringValvulaCorte", "BlueMeteringClienteId");
            DropColumn("dbo.BlueMeteringHidrometro", "BlueMeteringValvulaCorteId");
        }
    }
}
