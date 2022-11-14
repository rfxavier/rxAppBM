namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v40 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "BlueMeteringClienteId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BlueMeteringHidrometro", "BlueMeteringClienteId");
            AddForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringClienteId", "dbo.BlueMeteringCliente", "BlueMeteringClienteId");
            DropColumn("dbo.AspNetUsers", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Guid());
            DropForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.BlueMeteringHidrometro", new[] { "BlueMeteringClienteId" });
            DropColumn("dbo.BlueMeteringHidrometro", "BlueMeteringClienteId");
        }
    }
}
