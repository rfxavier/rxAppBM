namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringLigacao",
                c => new
                    {
                        BlueMeteringLigacaoId = c.Guid(nullable: false),
                        LigacaoId = c.String(maxLength: 250, unicode: false),
                        Rgi = c.String(maxLength: 250, unicode: false),
                        Endereco = c.String(maxLength: 250, unicode: false),
                        latitude = c.Decimal(precision: 18, scale: 2),
                        longitude = c.Decimal(precision: 18, scale: 2),
                        DeviceId = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.BlueMeteringLigacaoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlueMeteringLigacao");
        }
    }
}
