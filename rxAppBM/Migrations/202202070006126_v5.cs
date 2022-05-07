namespace rxApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cofre",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        id_cofre = c.String(nullable: false, maxLength: 50, unicode: false),
                        nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        serie = c.String(maxLength: 50, unicode: false),
                        tipo = c.String(maxLength: 50, unicode: false),
                        marca = c.String(maxLength: 50, unicode: false),
                        modelo = c.String(maxLength: 50, unicode: false),
                        tamanho_malote = c.String(maxLength: 50, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                        cod_loja = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cofre");
        }
    }
}
