namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BlueMeteringClienteId", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "BlueMeteringClienteId");
            AddForeignKey("dbo.AspNetUsers", "BlueMeteringClienteId", "dbo.BlueMeteringCliente", "BlueMeteringClienteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.AspNetUsers", new[] { "BlueMeteringClienteId" });
            DropColumn("dbo.AspNetUsers", "BlueMeteringClienteId");
        }
    }
}
