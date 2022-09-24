namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "IdCliente", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlueMeteringHidrometro", "IdCliente");
        }
    }
}
