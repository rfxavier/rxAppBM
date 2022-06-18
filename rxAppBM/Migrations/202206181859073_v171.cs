namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v171 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringConsumidorTipo",
                c => new
                    {
                        BlueMeteringConsumidorTipoId = c.Guid(nullable: false),
                        IdConsumidorTipo = c.String(maxLength: 250, unicode: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.BlueMeteringConsumidorTipoId);
            
            AddColumn("dbo.BlueMeteringConsumidor", "IdTipo", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlueMeteringConsumidor", "IdTipo");
            DropTable("dbo.BlueMeteringConsumidorTipo");
        }
    }
}
