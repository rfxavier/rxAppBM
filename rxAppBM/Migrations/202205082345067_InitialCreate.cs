namespace rxAppBM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlueMeteringMessage",
                c => new
                    {
                        BlueMeteringMessageId = c.Guid(nullable: false),
                        ParamsRxTime = c.Double(nullable: false),
                        ParamsPort = c.Int(nullable: false),
                        ParamsDuplicate = c.Boolean(nullable: false),
                        ParamsRadioGpsTime = c.Long(nullable: false),
                        ParamsRadioDelay = c.Double(nullable: false),
                        ParamsRadioDataRate = c.Int(nullable: false),
                        ParamsRadioModulationBandwidth = c.Long(nullable: false),
                        ParamsRadioModulationType = c.String(maxLength: 250, unicode: false),
                        ParamsRadioModulationSpreading = c.Int(nullable: false),
                        ParamsRadioModulationCodeRate = c.String(maxLength: 250, unicode: false),
                        ParamsRadioHardwareStatus = c.Int(nullable: false),
                        ParamsRadioHardwareChain = c.Int(nullable: false),
                        ParamsRadioHardwareTmst = c.Long(nullable: false),
                        ParamsRadioHardwareSnr = c.Double(nullable: false),
                        ParamsRadioHardwareRssi = c.Double(nullable: false),
                        ParamsRadioHardwareChannel = c.Double(nullable: false),
                        ParamsRadioHardwareGpsLat = c.Double(nullable: false),
                        ParamsRadioHardwareGpsLng = c.Double(nullable: false),
                        ParamsRadioHardwareGpsAlt = c.Int(nullable: false),
                        ParamsRadioTime = c.Double(nullable: false),
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
                        MetaDevice = c.String(maxLength: 250, unicode: false),
                        MetaPacketId = c.String(maxLength: 250, unicode: false),
                        MetaGateway = c.String(maxLength: 250, unicode: false),
                        Type = c.String(maxLength: 250, unicode: false),
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 250, unicode: false),
                        CompanyId = c.Guid(),
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
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CompanyId)
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
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Company");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.BlueMeteringMessage");
        }
    }
}
