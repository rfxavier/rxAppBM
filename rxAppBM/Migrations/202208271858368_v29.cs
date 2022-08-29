namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringConsumoPorDia",
                c => new
                    {
                        BlueMeteringConsumoPordiaId = c.Guid(nullable: false),
                        PayloadId = c.String(maxLength: 250, unicode: false),
                        TimestampDate = c.DateTime(nullable: false),
                        BlueMeteringMessageIdStartOfMonthDay = c.Guid(nullable: false),
                        BlueMeteringMessageIdEndOfMonthDay = c.Guid(nullable: false),
                        PayloadVolLitersDelta = c.Long(),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.BlueMeteringConsumoPordiaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlueMeteringConsumoPorDia");
        }
    }
}
