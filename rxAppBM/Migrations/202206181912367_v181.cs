namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v181 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringConsumidor", "IdConsumidorTipo", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.BlueMeteringConsumidor", "IdTipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringConsumidor", "IdTipo", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.BlueMeteringConsumidor", "IdConsumidorTipo");
        }
    }
}
