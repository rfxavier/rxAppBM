namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringMessage", "PayloadId", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.BlueMeteringMessage", "PayloadVolLiters", c => c.Long(nullable: false));
            AddColumn("dbo.BlueMeteringMessage", "PayloadVolM3", c => c.Long(nullable: false));
            AddColumn("dbo.BlueMeteringMessage", "PayloadTemp", c => c.Int(nullable: false));
            AddColumn("dbo.BlueMeteringMessage", "PayloadBatt", c => c.Int(nullable: false));
            AddColumn("dbo.BlueMeteringMessage", "PayloadAlarm", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlueMeteringMessage", "PayloadAlarm");
            DropColumn("dbo.BlueMeteringMessage", "PayloadBatt");
            DropColumn("dbo.BlueMeteringMessage", "PayloadTemp");
            DropColumn("dbo.BlueMeteringMessage", "PayloadVolM3");
            DropColumn("dbo.BlueMeteringMessage", "PayloadVolLiters");
            DropColumn("dbo.BlueMeteringMessage", "PayloadId");
        }
    }
}
