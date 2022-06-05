namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlueMeteringMessage", "PayloadVolLiters", c => c.Long());
            AlterColumn("dbo.BlueMeteringMessage", "PayloadVolM3", c => c.Long());
            AlterColumn("dbo.BlueMeteringMessage", "PayloadTemp", c => c.Int());
            AlterColumn("dbo.BlueMeteringMessage", "PayloadBatt", c => c.Int());
            AlterColumn("dbo.BlueMeteringMessage", "PayloadAlarm", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlueMeteringMessage", "PayloadAlarm", c => c.Int(nullable: false));
            AlterColumn("dbo.BlueMeteringMessage", "PayloadBatt", c => c.Int(nullable: false));
            AlterColumn("dbo.BlueMeteringMessage", "PayloadTemp", c => c.Int(nullable: false));
            AlterColumn("dbo.BlueMeteringMessage", "PayloadVolM3", c => c.Long(nullable: false));
            AlterColumn("dbo.BlueMeteringMessage", "PayloadVolLiters", c => c.Long(nullable: false));
        }
    }
}
