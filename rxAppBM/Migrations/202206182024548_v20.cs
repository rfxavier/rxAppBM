namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringHidrometro",
                c => new
                    {
                        BlueMeteringHidrometroId = c.Guid(nullable: false),
                        IdHidrometro = c.String(maxLength: 250, unicode: false),
                        RedeIotId = c.String(maxLength: 250, unicode: false),
                        NumeroSerie = c.String(maxLength: 250, unicode: false),
                        IdHidrometroTipo = c.String(maxLength: 250, unicode: false),
                        Capacidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumeroSerieRelojoaria = c.String(maxLength: 250, unicode: false),
                        MarcacaoInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BlueMeteringHidrometroId);
            
            CreateTable(
                "dbo.BlueMeteringHidrometroTipo",
                c => new
                    {
                        BlueMeteringHidrometroTipoId = c.Guid(nullable: false),
                        IdHidrometroTipo = c.String(maxLength: 250, unicode: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.BlueMeteringHidrometroTipoId);
            
            CreateTable(
                "dbo.BlueMeteringValvulaCorte",
                c => new
                    {
                        BlueMeteringValvulaCorteId = c.Guid(nullable: false),
                        IdValvulaCorte = c.String(maxLength: 250, unicode: false),
                        NumeroSerie = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.BlueMeteringValvulaCorteId);
            
            AddColumn("dbo.BlueMeteringLigacao", "IdHidrometro", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.BlueMeteringLigacao", "IdValvulaCorte", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlueMeteringLigacao", "IdValvulaCorte");
            DropColumn("dbo.BlueMeteringLigacao", "IdHidrometro");
            DropTable("dbo.BlueMeteringValvulaCorte");
            DropTable("dbo.BlueMeteringHidrometroTipo");
            DropTable("dbo.BlueMeteringHidrometro");
        }
    }
}
