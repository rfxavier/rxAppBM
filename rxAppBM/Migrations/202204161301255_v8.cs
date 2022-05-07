namespace rxApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.message", "data_currency_bill", c => c.Long());
            AddColumn("dbo.message", "data_currency_bill_total", c => c.Long());
            AddColumn("dbo.message", "data_sensor", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.message", "data_sensor");
            DropColumn("dbo.message", "data_currency_bill_total");
            DropColumn("dbo.message", "data_currency_bill");
        }
    }
}
