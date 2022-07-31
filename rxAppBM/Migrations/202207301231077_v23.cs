namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "DeviceId", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.BlueMeteringLigacao", "DeviceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringLigacao", "DeviceId", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.BlueMeteringHidrometro", "DeviceId");
        }
    }
}
