namespace rxApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GetLockLojaId", c => c.Long());
            CreateIndex("dbo.AspNetUsers", "GetLockLojaId");
            AddForeignKey("dbo.AspNetUsers", "GetLockLojaId", "dbo.loja", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GetLockLojaId", "dbo.loja");
            DropIndex("dbo.AspNetUsers", new[] { "GetLockLojaId" });
            DropColumn("dbo.AspNetUsers", "GetLockLojaId");
        }
    }
}
