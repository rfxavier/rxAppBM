namespace rxApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.message",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        info_id = c.String(maxLength: 50, unicode: false),
                        info_ip = c.String(maxLength: 50, unicode: false),
                        info_mac = c.String(maxLength: 50, unicode: false),
                        info_json = c.String(maxLength: 50, unicode: false),
                        data_hash = c.String(maxLength: 50, unicode: false),
                        data_tmst_begin = c.String(maxLength: 50, unicode: false),
                        data_tmst_end = c.String(maxLength: 50, unicode: false),
                        data_user = c.String(maxLength: 50, unicode: false),
                        data_type = c.String(maxLength: 50, unicode: false),
                        data_currency_total = c.Decimal(precision: 18, scale: 2),
                        data_currency_bill_2 = c.Long(),
                        data_currency_bill_5 = c.Long(),
                        data_currency_bill_10 = c.Long(),
                        data_currency_bill_20 = c.Long(),
                        data_currency_bill_50 = c.Long(),
                        data_currency_bill_100 = c.Long(),
                        data_currency_bill_200 = c.Long(),
                        data_currency_bill_rejected = c.Long(),
                        data_currency_envelope = c.Long(),
                        data_currency_envelope_total = c.Decimal(precision: 18, scale: 2),
                        id_cofre = c.String(maxLength: 50, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                        data_tmst_begin_datetime = c.DateTime(),
                        data_tmst_end_datetime = c.DateTime(),
                        cod_loja = c.String(maxLength: 50, unicode: false),
                        cod_cliente = c.String(maxLength: 50, unicode: false),
                        cod_rede = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.message");
        }
    }
}
