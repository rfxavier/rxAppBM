namespace rxApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RsData",
                c => new
                    {
                        RsDataId = c.Long(nullable: false, identity: true),
                        TestField = c.String(maxLength: 250, unicode: false),
                        DateCreated = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RsDataId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RsData");
        }
    }
}
