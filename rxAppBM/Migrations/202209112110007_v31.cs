namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringCliente",
                c => new
                    {
                        BlueMeteringClienteId = c.Guid(nullable: false),
                        IdCliente = c.String(maxLength: 250, unicode: false),
                        NomeFantasia = c.String(maxLength: 250, unicode: false),
                        CNPJ = c.String(maxLength: 250, unicode: false),
                        Endereco = c.String(maxLength: 250, unicode: false),
                        latitude = c.Decimal(precision: 18, scale: 2),
                        longitude = c.Decimal(precision: 18, scale: 2),
                        PessoaContato = c.String(maxLength: 250, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        Telefone = c.String(maxLength: 250, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.BlueMeteringClienteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlueMeteringCliente");
        }
    }
}
