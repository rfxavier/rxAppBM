namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v42 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "BlueMeteringHidrometroTipoId", c => c.Guid());
            AddColumn("dbo.BlueMeteringHidrometroTipo", "BlueMeteringClienteId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BlueMeteringHidrometro", "BlueMeteringHidrometroTipoId");
            CreateIndex("dbo.BlueMeteringHidrometroTipo", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringHidrometroTipo", "BlueMeteringClienteId", "dbo.BlueMeteringCliente", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringHidrometroTipoId", "dbo.BlueMeteringHidrometroTipo", "BlueMeteringHidrometroTipoId");
            DropColumn("dbo.BlueMeteringHidrometro", "IdHidrometroTipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "IdHidrometroTipo", c => c.String(maxLength: 250, unicode: false));
            DropForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringHidrometroTipoId", "dbo.BlueMeteringHidrometroTipo");
            DropForeignKey("dbo.BlueMeteringHidrometroTipo", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.BlueMeteringHidrometroTipo", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringHidrometro", new[] { "BlueMeteringHidrometroTipoId" });
            DropColumn("dbo.BlueMeteringHidrometroTipo", "BlueMeteringClienteId");
            DropColumn("dbo.BlueMeteringHidrometro", "BlueMeteringHidrometroTipoId");
        }
    }
}
