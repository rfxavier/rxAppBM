namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v39 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Company");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropTable("dbo.Company");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateIndex("dbo.AspNetUsers", "CompanyId");
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Company", "CompanyId");
        }
    }
}
