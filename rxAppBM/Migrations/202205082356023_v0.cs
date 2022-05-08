namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringMessage", "trackLastWriteTime", c => c.DateTime());
            AddColumn("dbo.BlueMeteringMessage", "trackCreationTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlueMeteringMessage", "trackCreationTime");
            DropColumn("dbo.BlueMeteringMessage", "trackLastWriteTime");
        }
    }
}
