namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlueMeteringHidrometro", "IdValvulaCorte", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.BlueMeteringLigacao", "IdValvulaCorte");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlueMeteringLigacao", "IdValvulaCorte", c => c.String(maxLength: 250, unicode: false));
            DropColumn("dbo.BlueMeteringHidrometro", "IdValvulaCorte");
        }
    }
}
