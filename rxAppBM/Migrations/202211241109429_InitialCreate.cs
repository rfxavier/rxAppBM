namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringAlarm",
                c => new
                    {
                        BlueMeteringAlarmId = c.Guid(nullable: false),
                        PayloadAlarm = c.Int(nullable: false),
                        PayloadAlarmDescription = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.BlueMeteringAlarmId);
            
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
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 250, unicode: false),
                        BlueMeteringClienteId = c.Guid(),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 250, unicode: false),
                        SecurityStamp = c.String(maxLength: 250, unicode: false),
                        PhoneNumber = c.String(maxLength: 250, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlueMeteringCliente", t => t.BlueMeteringClienteId)
                .Index(t => t.BlueMeteringClienteId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                        ClaimType = c.String(maxLength: 250, unicode: false),
                        ClaimValue = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 250, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 250, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.BlueMeteringConsumidor",
                c => new
                    {
                        BlueMeteringConsumidorId = c.Guid(nullable: false),
                        IdConsumidor = c.String(maxLength: 250, unicode: false),
                        IdExternoConsumidor = c.String(maxLength: 250, unicode: false),
                        NomeCompleto = c.String(maxLength: 250, unicode: false),
                        CPF = c.String(maxLength: 250, unicode: false),
                        RG = c.String(maxLength: 250, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                        BlueMeteringConsumidorTipoId = c.Guid(),
                        BlueMeteringClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BlueMeteringConsumidorId)
                .ForeignKey("dbo.BlueMeteringCliente", t => t.BlueMeteringClienteId)
                .ForeignKey("dbo.BlueMeteringConsumidorTipo", t => t.BlueMeteringConsumidorTipoId)
                .Index(t => t.BlueMeteringConsumidorTipoId)
                .Index(t => t.BlueMeteringClienteId);
            
            CreateTable(
                "dbo.BlueMeteringConsumidorTipo",
                c => new
                    {
                        BlueMeteringConsumidorTipoId = c.Guid(nullable: false),
                        IdConsumidorTipo = c.String(maxLength: 250, unicode: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        BlueMeteringClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BlueMeteringConsumidorTipoId)
                .ForeignKey("dbo.BlueMeteringCliente", t => t.BlueMeteringClienteId)
                .Index(t => t.BlueMeteringClienteId);
            
            CreateTable(
                "dbo.BlueMeteringLigacao",
                c => new
                    {
                        BlueMeteringLigacaoId = c.Guid(nullable: false),
                        LigacaoId = c.String(maxLength: 250, unicode: false),
                        Rgi = c.String(maxLength: 250, unicode: false),
                        Endereco = c.String(maxLength: 250, unicode: false),
                        latitude = c.Decimal(precision: 18, scale: 2),
                        longitude = c.Decimal(precision: 18, scale: 2),
                        BlueMeteringConsumidorId = c.Guid(),
                        BlueMeteringUnidadeNegocioId = c.Guid(),
                        BlueMeteringClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BlueMeteringLigacaoId)
                .ForeignKey("dbo.BlueMeteringCliente", t => t.BlueMeteringClienteId)
                .ForeignKey("dbo.BlueMeteringConsumidor", t => t.BlueMeteringConsumidorId)
                .ForeignKey("dbo.BlueMeteringUnidadeNegocio", t => t.BlueMeteringUnidadeNegocioId)
                .Index(t => t.BlueMeteringConsumidorId)
                .Index(t => t.BlueMeteringUnidadeNegocioId)
                .Index(t => t.BlueMeteringClienteId);
            
            CreateTable(
                "dbo.BlueMeteringHidrometro",
                c => new
                    {
                        BlueMeteringHidrometroId = c.Guid(nullable: false),
                        IdHidrometro = c.String(maxLength: 250, unicode: false),
                        RedeIotId = c.String(maxLength: 250, unicode: false),
                        NumeroSerie = c.String(maxLength: 250, unicode: false),
                        BlueMeteringHidrometroTipoId = c.Guid(),
                        Capacidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumeroSerieRelojoaria = c.String(maxLength: 250, unicode: false),
                        MarcacaoInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeviceId = c.String(maxLength: 250, unicode: false),
                        BlueMeteringLigacaoId = c.Guid(),
                        BlueMeteringValvulaCorteId = c.Guid(),
                        BlueMeteringClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BlueMeteringHidrometroId)
                .ForeignKey("dbo.BlueMeteringCliente", t => t.BlueMeteringClienteId)
                .ForeignKey("dbo.BlueMeteringHidrometroTipo", t => t.BlueMeteringHidrometroTipoId)
                .ForeignKey("dbo.BlueMeteringLigacao", t => t.BlueMeteringLigacaoId)
                .ForeignKey("dbo.BlueMeteringValvulaCorte", t => t.BlueMeteringValvulaCorteId)
                .Index(t => t.BlueMeteringHidrometroTipoId)
                .Index(t => t.BlueMeteringLigacaoId)
                .Index(t => t.BlueMeteringValvulaCorteId)
                .Index(t => t.BlueMeteringClienteId);
            
            CreateTable(
                "dbo.BlueMeteringHidrometroTipo",
                c => new
                    {
                        BlueMeteringHidrometroTipoId = c.Guid(nullable: false),
                        IdHidrometroTipo = c.String(maxLength: 250, unicode: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        BlueMeteringClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BlueMeteringHidrometroTipoId)
                .ForeignKey("dbo.BlueMeteringCliente", t => t.BlueMeteringClienteId)
                .Index(t => t.BlueMeteringClienteId);
            
            CreateTable(
                "dbo.BlueMeteringValvulaCorte",
                c => new
                    {
                        BlueMeteringValvulaCorteId = c.Guid(nullable: false),
                        IdValvulaCorte = c.String(maxLength: 250, unicode: false),
                        NumeroSerie = c.String(maxLength: 250, unicode: false),
                        BlueMeteringClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BlueMeteringValvulaCorteId)
                .ForeignKey("dbo.BlueMeteringCliente", t => t.BlueMeteringClienteId)
                .Index(t => t.BlueMeteringClienteId);
            
            CreateTable(
                "dbo.BlueMeteringUnidadeNegocio",
                c => new
                    {
                        BlueMeteringUnidadeNegocioId = c.Guid(nullable: false),
                        IdUnidadeNegocio = c.String(maxLength: 250, unicode: false),
                        Nome = c.String(maxLength: 250, unicode: false),
                        Endereco = c.String(maxLength: 250, unicode: false),
                        latitude = c.Decimal(precision: 18, scale: 2),
                        longitude = c.Decimal(precision: 18, scale: 2),
                        BlueMeteringUnidadeGerenciamentoRegionalId = c.Guid(),
                        BlueMeteringClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BlueMeteringUnidadeNegocioId)
                .ForeignKey("dbo.BlueMeteringCliente", t => t.BlueMeteringClienteId)
                .ForeignKey("dbo.BlueMeteringUnidadeGerenciamentoRegional", t => t.BlueMeteringUnidadeGerenciamentoRegionalId)
                .Index(t => t.BlueMeteringUnidadeGerenciamentoRegionalId)
                .Index(t => t.BlueMeteringClienteId);
            
            CreateTable(
                "dbo.BlueMeteringUnidadeGerenciamentoRegional",
                c => new
                    {
                        BlueMeteringUnidadeGerenciamentoRegionalId = c.Guid(nullable: false),
                        IdUnidadeGerenciamentoRegional = c.String(maxLength: 250, unicode: false),
                        Nome = c.String(maxLength: 250, unicode: false),
                        Endereco = c.String(maxLength: 250, unicode: false),
                        latitude = c.Decimal(precision: 18, scale: 2),
                        longitude = c.Decimal(precision: 18, scale: 2),
                        BlueMeteringClienteId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BlueMeteringUnidadeGerenciamentoRegionalId)
                .ForeignKey("dbo.BlueMeteringCliente", t => t.BlueMeteringClienteId)
                .Index(t => t.BlueMeteringClienteId);
            
            CreateTable(
                "dbo.BlueMeteringConsumoPorDia",
                c => new
                    {
                        BlueMeteringConsumoPordiaId = c.Guid(nullable: false),
                        PayloadId = c.String(maxLength: 250, unicode: false),
                        TimestampDate = c.DateTime(nullable: false),
                        BlueMeteringMessageIdStartOfMonthDay = c.Guid(nullable: false),
                        BlueMeteringMessageIdEndOfMonthDay = c.Guid(nullable: false),
                        PayloadVolLitersDelta = c.Long(),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.BlueMeteringConsumoPordiaId);
            
            CreateTable(
                "dbo.consumoPorDia_view",
                c => new
                    {
                        BlueMeteringConsumoPordiaId = c.Guid(nullable: false),
                        PayloadId = c.String(maxLength: 250, unicode: false),
                        TimestampDate = c.DateTime(nullable: false),
                        BlueMeteringMessageIdStartOfMonthDay = c.Guid(nullable: false),
                        BlueMeteringMessageIdEndOfMonthDay = c.Guid(nullable: false),
                        PayloadVolLitersDelta = c.Long(),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                        LigacaoId = c.String(maxLength: 250, unicode: false),
                        LigacaoRgi = c.String(maxLength: 250, unicode: false),
                        LigacaoEndereco = c.String(maxLength: 250, unicode: false),
                        LigacaoLatitude = c.Decimal(precision: 18, scale: 2),
                        LigacaoLongitude = c.Decimal(precision: 18, scale: 2),
                        ConsumidorIdConsumidor = c.String(maxLength: 250, unicode: false),
                        ConsumidorIdExternoConsumidor = c.String(maxLength: 250, unicode: false),
                        ConsumidorNomeCompleto = c.String(maxLength: 250, unicode: false),
                        ConsumidorCPF = c.String(maxLength: 250, unicode: false),
                        ConsumidorRG = c.String(maxLength: 250, unicode: false),
                        ConsumidorTipo = c.String(maxLength: 250, unicode: false),
                        HidrometroIdHidrometro = c.String(maxLength: 250, unicode: false),
                        HidrometroRedeIotId = c.String(maxLength: 250, unicode: false),
                        HidrometroNumeroSerie = c.String(maxLength: 250, unicode: false),
                        HidrometroTipoDescricao = c.String(maxLength: 250, unicode: false),
                        HidrometroCapacidade = c.Decimal(precision: 18, scale: 2),
                        HidrometroNumeroSerieRelojoaria = c.String(maxLength: 250, unicode: false),
                        HidrometroMarcacaoInicial = c.Decimal(precision: 18, scale: 2),
                        ClienteId = c.Guid(),
                        ClienteNome = c.String(maxLength: 250, unicode: false),
                        ClienteCNPJ = c.String(maxLength: 250, unicode: false),
                        ClienteEndereco = c.String(maxLength: 250, unicode: false),
                        ClienteLatitude = c.Decimal(precision: 18, scale: 2),
                        ClienteLongitude = c.Decimal(precision: 18, scale: 2),
                        ClienteEmail = c.String(maxLength: 250, unicode: false),
                        ClienteTelefone = c.String(maxLength: 250, unicode: false),
                        ValvulaCorteIdValvulaCorte = c.String(maxLength: 250, unicode: false),
                        ValvulaCorteNumeroSerie = c.String(maxLength: 250, unicode: false),
                        UnidadeNegocioIdUnidadeNegocio = c.String(maxLength: 250, unicode: false),
                        UnidadeNegocioNome = c.String(maxLength: 250, unicode: false),
                        UnidadeNegocioEndereco = c.String(maxLength: 250, unicode: false),
                        UnidadeNegocioLatitude = c.Decimal(precision: 18, scale: 2),
                        UnidadeNegocioLongitude = c.Decimal(precision: 18, scale: 2),
                        UnidadeGerenciamentoRegionalIdUnidadeGerenciamentoRegional = c.String(maxLength: 250, unicode: false),
                        UnidadeGerenciamentoRegionalNome = c.String(maxLength: 250, unicode: false),
                        UnidadeGerenciamentoRegionalEndereco = c.String(maxLength: 250, unicode: false),
                        UnidadeGerenciamentoRegionalLatitude = c.Decimal(precision: 18, scale: 2),
                        UnidadeGerenciamentoRegionalLongitude = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BlueMeteringConsumoPordiaId);
            
            CreateTable(
                "dbo.BlueMeteringMessage",
                c => new
                    {
                        BlueMeteringMessageId = c.Guid(nullable: false),
                        ParamsRxTime = c.Double(nullable: false),
                        ParamsRxTimeDateTime = c.DateTime(),
                        ParamsPort = c.Int(nullable: false),
                        ParamsDuplicate = c.Boolean(nullable: false),
                        ParamsRadioGpsTime = c.Long(nullable: false),
                        ParamsRadioGpsTimeDateTime = c.DateTime(),
                        ParamsRadioDelay = c.Double(nullable: false),
                        ParamsRadioDataRate = c.Int(nullable: false),
                        ParamsRadioModulationBandwidth = c.Long(nullable: false),
                        ParamsRadioModulationType = c.String(maxLength: 250, unicode: false),
                        ParamsRadioModulationSpreading = c.Int(nullable: false),
                        ParamsRadioModulationCodeRate = c.String(maxLength: 250, unicode: false),
                        ParamsRadioHardwareStatus = c.Int(nullable: false),
                        ParamsRadioHardwareChain = c.Int(nullable: false),
                        ParamsRadioHardwareTmst = c.Long(nullable: false),
                        ParamsRadioHardwareTmstDateTime = c.DateTime(),
                        ParamsRadioHardwareSnr = c.Double(nullable: false),
                        ParamsRadioHardwareRssi = c.Double(nullable: false),
                        ParamsRadioHardwareChannel = c.Double(nullable: false),
                        ParamsRadioHardwareGpsLat = c.Double(nullable: false),
                        ParamsRadioHardwareGpsLng = c.Double(nullable: false),
                        ParamsRadioHardwareGpsAlt = c.Int(nullable: false),
                        ParamsRadioTime = c.Double(nullable: false),
                        ParamsRadioTimeDateTime = c.DateTime(),
                        ParamsRadioFrequency = c.Double(nullable: false),
                        ParamsRadioSize = c.Int(nullable: false),
                        ParamsCounterUp = c.Int(nullable: false),
                        ParamsLoraHeaderClassB = c.Boolean(nullable: false),
                        ParamsLoraHeaderConfirmed = c.Boolean(nullable: false),
                        ParamsLoraHeaderAdr = c.Boolean(nullable: false),
                        ParamsLoraHeaderAck = c.Boolean(nullable: false),
                        ParamsLoraHeaderAdrAckReq = c.Boolean(nullable: false),
                        ParamsLoraHeaderVersion = c.Int(nullable: false),
                        ParamsLoraHeaderType = c.Int(nullable: false),
                        ParamsPayload = c.String(maxLength: 250, unicode: false),
                        ParamsEncryptedPayload = c.String(maxLength: 250, unicode: false),
                        MetaNetwork = c.String(maxLength: 250, unicode: false),
                        MetaPacketHash = c.String(maxLength: 250, unicode: false),
                        MetaApplication = c.String(maxLength: 250, unicode: false),
                        MetaDeviceAddr = c.String(maxLength: 250, unicode: false),
                        MetaTime = c.Double(nullable: false),
                        MetaTimeDateTime = c.DateTime(),
                        MetaDevice = c.String(maxLength: 250, unicode: false),
                        MetaPacketId = c.String(maxLength: 250, unicode: false),
                        MetaGateway = c.String(maxLength: 250, unicode: false),
                        Type = c.String(maxLength: 250, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                        PayloadId = c.String(maxLength: 250, unicode: false),
                        PayloadVolLiters = c.Long(),
                        PayloadVolM3 = c.Long(),
                        PayloadTemp = c.Int(),
                        PayloadBatt = c.Int(),
                        PayloadAlarm = c.Int(),
                    })
                .PrimaryKey(t => t.BlueMeteringMessageId);
            
            CreateTable(
                "dbo.message_view",
                c => new
                    {
                        BlueMeteringMessageId = c.Guid(nullable: false),
                        ParamsRxTime = c.Double(nullable: false),
                        ParamsRxTimeDateTime = c.DateTime(),
                        ParamsPort = c.Int(nullable: false),
                        ParamsDuplicate = c.Boolean(nullable: false),
                        ParamsRadioGpsTime = c.Long(nullable: false),
                        ParamsRadioGpsTimeDateTime = c.DateTime(),
                        ParamsRadioDelay = c.Double(nullable: false),
                        ParamsRadioDataRate = c.Int(nullable: false),
                        ParamsRadioModulationBandwidth = c.Long(nullable: false),
                        ParamsRadioModulationType = c.String(maxLength: 250, unicode: false),
                        ParamsRadioModulationSpreading = c.Int(nullable: false),
                        ParamsRadioModulationCodeRate = c.String(maxLength: 250, unicode: false),
                        ParamsRadioHardwareStatus = c.Int(nullable: false),
                        ParamsRadioHardwareChain = c.Int(nullable: false),
                        ParamsRadioHardwareTmst = c.Long(nullable: false),
                        ParamsRadioHardwareTmstDateTime = c.DateTime(),
                        ParamsRadioHardwareSnr = c.Double(nullable: false),
                        ParamsRadioHardwareRssi = c.Double(nullable: false),
                        ParamsRadioHardwareChannel = c.Double(nullable: false),
                        ParamsRadioHardwareGpsLat = c.Double(nullable: false),
                        ParamsRadioHardwareGpsLng = c.Double(nullable: false),
                        ParamsRadioHardwareGpsAlt = c.Int(nullable: false),
                        ParamsRadioTime = c.Double(nullable: false),
                        ParamsRadioTimeDateTime = c.DateTime(),
                        ParamsRadioFrequency = c.Double(nullable: false),
                        ParamsRadioSize = c.Int(nullable: false),
                        ParamsCounterUp = c.Int(nullable: false),
                        ParamsLoraHeaderClassB = c.Boolean(nullable: false),
                        ParamsLoraHeaderConfirmed = c.Boolean(nullable: false),
                        ParamsLoraHeaderAdr = c.Boolean(nullable: false),
                        ParamsLoraHeaderAck = c.Boolean(nullable: false),
                        ParamsLoraHeaderAdrAckReq = c.Boolean(nullable: false),
                        ParamsLoraHeaderVersion = c.Int(nullable: false),
                        ParamsLoraHeaderType = c.Int(nullable: false),
                        ParamsPayload = c.String(maxLength: 250, unicode: false),
                        ParamsEncryptedPayload = c.String(maxLength: 250, unicode: false),
                        MetaNetwork = c.String(maxLength: 250, unicode: false),
                        MetaPacketHash = c.String(maxLength: 250, unicode: false),
                        MetaApplication = c.String(maxLength: 250, unicode: false),
                        MetaDeviceAddr = c.String(maxLength: 250, unicode: false),
                        MetaTime = c.Double(nullable: false),
                        MetaTimeDateTime = c.DateTime(),
                        MetaDevice = c.String(maxLength: 250, unicode: false),
                        MetaPacketId = c.String(maxLength: 250, unicode: false),
                        MetaGateway = c.String(maxLength: 250, unicode: false),
                        Type = c.String(maxLength: 250, unicode: false),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                        PayloadId = c.String(maxLength: 250, unicode: false),
                        PayloadVolLiters = c.Long(),
                        PayloadVolM3 = c.Long(),
                        PayloadTemp = c.Int(),
                        PayloadBatt = c.Int(),
                        PayloadAlarm = c.Int(),
                        PayloadAlarmDescription = c.String(maxLength: 250, unicode: false),
                        LigacaoId = c.String(maxLength: 250, unicode: false),
                        LigacaoRgi = c.String(maxLength: 250, unicode: false),
                        LigacaoEndereco = c.String(maxLength: 250, unicode: false),
                        LigacaoLatitude = c.Decimal(precision: 18, scale: 2),
                        LigacaoLongitude = c.Decimal(precision: 18, scale: 2),
                        ConsumidorIdConsumidor = c.String(maxLength: 250, unicode: false),
                        ConsumidorIdExternoConsumidor = c.String(maxLength: 250, unicode: false),
                        ConsumidorNomeCompleto = c.String(maxLength: 250, unicode: false),
                        ConsumidorCPF = c.String(maxLength: 250, unicode: false),
                        ConsumidorRG = c.String(maxLength: 250, unicode: false),
                        ConsumidorTipo = c.String(maxLength: 250, unicode: false),
                        HidrometroIdHidrometro = c.String(maxLength: 250, unicode: false),
                        HidrometroRedeIotId = c.String(maxLength: 250, unicode: false),
                        HidrometroNumeroSerie = c.String(maxLength: 250, unicode: false),
                        HidrometroTipoDescricao = c.String(maxLength: 250, unicode: false),
                        HidrometroCapacidade = c.Decimal(precision: 18, scale: 2),
                        HidrometroNumeroSerieRelojoaria = c.String(maxLength: 250, unicode: false),
                        HidrometroMarcacaoInicial = c.Decimal(precision: 18, scale: 2),
                        ClienteIdCliente = c.String(maxLength: 250, unicode: false),
                        ClienteNomeFantasia = c.String(maxLength: 250, unicode: false),
                        ClienteCNPJ = c.String(maxLength: 250, unicode: false),
                        ClienteEndereco = c.String(maxLength: 250, unicode: false),
                        ClienteLatitude = c.Decimal(precision: 18, scale: 2),
                        ClienteLongitude = c.Decimal(precision: 18, scale: 2),
                        ClientePessoaContato = c.String(maxLength: 250, unicode: false),
                        ClienteEmail = c.String(maxLength: 250, unicode: false),
                        ClienteTelefone = c.String(maxLength: 250, unicode: false),
                        ValvulaCorteIdValvulaCorte = c.String(maxLength: 250, unicode: false),
                        ValvulaCorteNumeroSerie = c.String(maxLength: 250, unicode: false),
                        UnidadeNegocioIdUnidadeNegocio = c.String(maxLength: 250, unicode: false),
                        UnidadeNegocioNome = c.String(maxLength: 250, unicode: false),
                        UnidadeNegocioEndereco = c.String(maxLength: 250, unicode: false),
                        UnidadeNegocioLatitude = c.Decimal(precision: 18, scale: 2),
                        UnidadeNegocioLongitude = c.Decimal(precision: 18, scale: 2),
                        UnidadeGerenciamentoRegionalIdUnidadeGerenciamentoRegional = c.String(maxLength: 250, unicode: false),
                        UnidadeGerenciamentoRegionalNome = c.String(maxLength: 250, unicode: false),
                        UnidadeGerenciamentoRegionalEndereco = c.String(maxLength: 250, unicode: false),
                        UnidadeGerenciamentoRegionalLatitude = c.Decimal(precision: 18, scale: 2),
                        UnidadeGerenciamentoRegionalLongitude = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BlueMeteringMessageId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 250, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BlueMeteringLigacao", "BlueMeteringUnidadeNegocioId", "dbo.BlueMeteringUnidadeNegocio");
            DropForeignKey("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringUnidadeGerenciamentoRegionalId", "dbo.BlueMeteringUnidadeGerenciamentoRegional");
            DropForeignKey("dbo.BlueMeteringUnidadeGerenciamentoRegional", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropForeignKey("dbo.BlueMeteringUnidadeNegocio", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringValvulaCorteId", "dbo.BlueMeteringValvulaCorte");
            DropForeignKey("dbo.BlueMeteringValvulaCorte", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringLigacaoId", "dbo.BlueMeteringLigacao");
            DropForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringHidrometroTipoId", "dbo.BlueMeteringHidrometroTipo");
            DropForeignKey("dbo.BlueMeteringHidrometroTipo", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropForeignKey("dbo.BlueMeteringHidrometro", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropForeignKey("dbo.BlueMeteringLigacao", "BlueMeteringConsumidorId", "dbo.BlueMeteringConsumidor");
            DropForeignKey("dbo.BlueMeteringLigacao", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropForeignKey("dbo.BlueMeteringConsumidor", "BlueMeteringConsumidorTipoId", "dbo.BlueMeteringConsumidorTipo");
            DropForeignKey("dbo.BlueMeteringConsumidorTipo", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropForeignKey("dbo.BlueMeteringConsumidor", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "BlueMeteringClienteId", "dbo.BlueMeteringCliente");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.BlueMeteringUnidadeGerenciamentoRegional", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringUnidadeNegocio", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringUnidadeNegocio", new[] { "BlueMeteringUnidadeGerenciamentoRegionalId" });
            DropIndex("dbo.BlueMeteringValvulaCorte", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringHidrometroTipo", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringHidrometro", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringHidrometro", new[] { "BlueMeteringValvulaCorteId" });
            DropIndex("dbo.BlueMeteringHidrometro", new[] { "BlueMeteringLigacaoId" });
            DropIndex("dbo.BlueMeteringHidrometro", new[] { "BlueMeteringHidrometroTipoId" });
            DropIndex("dbo.BlueMeteringLigacao", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringLigacao", new[] { "BlueMeteringUnidadeNegocioId" });
            DropIndex("dbo.BlueMeteringLigacao", new[] { "BlueMeteringConsumidorId" });
            DropIndex("dbo.BlueMeteringConsumidorTipo", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringConsumidor", new[] { "BlueMeteringClienteId" });
            DropIndex("dbo.BlueMeteringConsumidor", new[] { "BlueMeteringConsumidorTipoId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "BlueMeteringClienteId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.message_view");
            DropTable("dbo.BlueMeteringMessage");
            DropTable("dbo.consumoPorDia_view");
            DropTable("dbo.BlueMeteringConsumoPorDia");
            DropTable("dbo.BlueMeteringUnidadeGerenciamentoRegional");
            DropTable("dbo.BlueMeteringUnidadeNegocio");
            DropTable("dbo.BlueMeteringValvulaCorte");
            DropTable("dbo.BlueMeteringHidrometroTipo");
            DropTable("dbo.BlueMeteringHidrometro");
            DropTable("dbo.BlueMeteringLigacao");
            DropTable("dbo.BlueMeteringConsumidorTipo");
            DropTable("dbo.BlueMeteringConsumidor");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BlueMeteringCliente");
            DropTable("dbo.BlueMeteringAlarm");
        }
    }
}
