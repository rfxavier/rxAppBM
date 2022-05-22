namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringMessage", "ParamsRxTimeDateTime", c => c.DateTime());
            AddColumn("dbo.BlueMeteringMessage", "ParamsRadioGpsTimeDateTime", c => c.DateTime());
            AddColumn("dbo.BlueMeteringMessage", "ParamsRadioHardwareTmstDateTime", c => c.DateTime());
            AddColumn("dbo.BlueMeteringMessage", "ParamsRadioTimeDateTime", c => c.DateTime());
            AddColumn("dbo.BlueMeteringMessage", "MetaTimeDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlueMeteringMessage", "MetaTimeDateTime");
            DropColumn("dbo.BlueMeteringMessage", "ParamsRadioTimeDateTime");
            DropColumn("dbo.BlueMeteringMessage", "ParamsRadioHardwareTmstDateTime");
            DropColumn("dbo.BlueMeteringMessage", "ParamsRadioGpsTimeDateTime");
            DropColumn("dbo.BlueMeteringMessage", "ParamsRxTimeDateTime");
        }
    }
}
