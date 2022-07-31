namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "IdLigacao", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.BlueMeteringLigacao", "IdHidrometro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringLigacao", "IdHidrometro", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.BlueMeteringHidrometro", "IdLigacao");
        }
    }
}
