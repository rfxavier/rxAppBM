namespace rxApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Guid());
            CreateIndex("dbo.AspNetUsers", "CompanyId");
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Company", "CompanyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Company");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropColumn("dbo.AspNetUsers", "CompanyId");
            DropTable("dbo.Company");
        }
    }
}
