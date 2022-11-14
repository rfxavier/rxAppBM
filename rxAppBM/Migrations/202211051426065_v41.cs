namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v41 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BlueMeteringHidrometro", "IdCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "IdCliente", c => c.String(maxLength: 250, unicode: false));
        }
    }
}
