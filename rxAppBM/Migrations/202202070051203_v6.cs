namespace rxApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        cod_cliente = c.String(nullable: false, maxLength: 50, unicode: false),
                        nome = c.String(maxLength: 50, unicode: false),
                        cod_rede = c.String(maxLength: 50, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                        razao_social = c.String(maxLength: 50, unicode: false),
                        cnpj = c.String(maxLength: 50, unicode: false),
                        endereco = c.String(maxLength: 60, unicode: false),
                        complemento = c.String(maxLength: 60, unicode: false),
                        bairro = c.String(maxLength: 50, unicode: false),
                        cidade = c.String(maxLength: 50, unicode: false),
                        uf = c.String(maxLength: 20, unicode: false),
                        CEP = c.String(maxLength: 10, unicode: false),
                        latitude = c.Decimal(precision: 18, scale: 2),
                        longitude = c.Decimal(precision: 18, scale: 2),
                        pessoa_contato = c.String(maxLength: 50, unicode: false),
                        email = c.String(maxLength: 100, unicode: false),
                        telefone = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.cofre_user",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        id_cofre = c.String(nullable: false, maxLength: 50, unicode: false),
                        data_user = c.String(nullable: false, maxLength: 50, unicode: false),
                        nome = c.String(maxLength: 50, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.loja",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        cod_loja = c.String(nullable: false, maxLength: 50, unicode: false),
                        cod_cliente = c.String(nullable: false, maxLength: 50, unicode: false),
                        nome = c.String(maxLength: 50, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                        razao_social = c.String(maxLength: 50, unicode: false),
                        cnpj = c.String(maxLength: 50, unicode: false),
                        endereco = c.String(maxLength: 60, unicode: false),
                        complemento = c.String(maxLength: 60, unicode: false),
                        bairro = c.String(maxLength: 50, unicode: false),
                        cidade = c.String(maxLength: 50, unicode: false),
                        uf = c.String(maxLength: 20, unicode: false),
                        CEP = c.String(maxLength: 10, unicode: false),
                        latitude = c.Decimal(precision: 18, scale: 2),
                        longitude = c.Decimal(precision: 18, scale: 2),
                        pessoa_contato = c.String(maxLength: 50, unicode: false),
                        email = c.String(maxLength: 100, unicode: false),
                        telefone = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.message_view",
                c => new
                    {
                        id = c.Long(nullable: false),
                        id_cofre = c.String(maxLength: 50, unicode: false),
                        cofre_nome = c.String(maxLength: 50, unicode: false),
                        cofre_serie = c.String(maxLength: 50, unicode: false),
                        cofre_tipo = c.String(maxLength: 50, unicode: false),
                        cofre_marca = c.String(maxLength: 50, unicode: false),
                        cofre_modelo = c.String(maxLength: 50, unicode: false),
                        cofre_tamanho_malote = c.String(maxLength: 50, unicode: false),
                        info_id = c.String(maxLength: 50, unicode: false),
                        info_ip = c.String(maxLength: 50, unicode: false),
                        info_mac = c.String(maxLength: 50, unicode: false),
                        info_json = c.String(maxLength: 50, unicode: false),
                        data_hash = c.String(maxLength: 50, unicode: false),
                        data_tmst_begin = c.String(maxLength: 50, unicode: false),
                        data_tmst_end = c.String(maxLength: 50, unicode: false),
                        data_user = c.String(maxLength: 50, unicode: false),
                        user_nome = c.String(maxLength: 50, unicode: false),
                        data_type = c.String(maxLength: 50, unicode: false),
                        movimento_nome = c.String(maxLength: 50, unicode: false),
                        movimento_tipo = c.String(maxLength: 50, unicode: false),
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
                        cod_loja = c.String(maxLength: 50, unicode: false),
                        nome_loja = c.String(maxLength: 50, unicode: false),
                        razao_social_loja = c.String(maxLength: 50, unicode: false),
                        cnpj_loja = c.String(maxLength: 50, unicode: false),
                        endereco_loja = c.String(maxLength: 60, unicode: false),
                        complemento_loja = c.String(maxLength: 60, unicode: false),
                        bairro_loja = c.String(maxLength: 50, unicode: false),
                        cidade_loja = c.String(maxLength: 50, unicode: false),
                        uf_loja = c.String(maxLength: 20, unicode: false),
                        cep_loja = c.String(maxLength: 10, unicode: false),
                        latitude_loja = c.Decimal(precision: 18, scale: 2),
                        longitude_loja = c.Decimal(precision: 18, scale: 2),
                        pessoa_contato_loja = c.String(maxLength: 50, unicode: false),
                        email_loja = c.String(maxLength: 100, unicode: false),
                        telefone_loja = c.String(maxLength: 20, unicode: false),
                        cod_cliente = c.String(maxLength: 50, unicode: false),
                        nome_cliente = c.String(maxLength: 50, unicode: false),
                        razao_social_cliente = c.String(maxLength: 50, unicode: false),
                        cnpj_cliente = c.String(maxLength: 50, unicode: false),
                        endereco_cliente = c.String(maxLength: 60, unicode: false),
                        complemento_cliente = c.String(maxLength: 60, unicode: false),
                        bairro_cliente = c.String(maxLength: 50, unicode: false),
                        cidade_cliente = c.String(maxLength: 50, unicode: false),
                        uf_cliente = c.String(maxLength: 20, unicode: false),
                        cep_cliente = c.String(maxLength: 10, unicode: false),
                        latitude_cliente = c.Decimal(precision: 18, scale: 2),
                        longitude_cliente = c.Decimal(precision: 18, scale: 2),
                        pessoa_contato_cliente = c.String(maxLength: 50, unicode: false),
                        email_cliente = c.String(maxLength: 100, unicode: false),
                        telefone_cliente = c.String(maxLength: 20, unicode: false),
                        cod_rede = c.String(maxLength: 50, unicode: false),
                        nome_rede = c.String(maxLength: 50, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                        data_tmst_begin_datetime = c.DateTime(),
                        data_tmst_end_datetime = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.movimento",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        data_type = c.String(nullable: false, maxLength: 50, unicode: false),
                        nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        tipo = c.String(maxLength: 50, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.rede",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        cod_rede = c.String(nullable: false, maxLength: 50, unicode: false),
                        nome = c.String(maxLength: 50, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.rede");
            DropTable("dbo.movimento");
            DropTable("dbo.message_view");
            DropTable("dbo.loja");
            DropTable("dbo.cofre_user");
            DropTable("dbo.cliente");
        }
    }
}
