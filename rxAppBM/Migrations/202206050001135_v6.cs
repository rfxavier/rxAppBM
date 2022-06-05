namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringAlarm",
                c => new
                    {
                        BlueMeteringAlarmId = c.Guid(nullable: false),
                        PayloadAlarm = c.Int(nullable: false),
                        PayloadAlarmDescription = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.BlueMeteringAlarmId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlueMeteringAlarm");
        }
    }
}
