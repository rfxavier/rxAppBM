namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v111 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringConsumidor",
                c => new
                    {
                        BlueMeteringConsumidorId = c.Guid(nullable: false),
                        IdConsumidor = c.String(maxLength: 250, unicode: false),
                        IdExternoConsumidor = c.String(maxLength: 250, unicode: false),
                        NomeCompleto = c.String(maxLength: 250, unicode: false),
                        CPF = c.String(maxLength: 250, unicode: false),
                        RG = c.String(maxLength: 250, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.BlueMeteringConsumidorId);
            
            AddColumn("dbo.BlueMeteringLigacao", "IdConsumidor", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlueMeteringLigacao", "IdConsumidor");
            DropTable("dbo.BlueMeteringConsumidor");
        }
    }
}
