namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "gtadmin.Birim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BirimAdi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "gtadmin.Urun",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Aciklama = c.String(),
                        Maliyet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mesafe = c.Int(),
                        AlinacakLokasyon = c.String(),
                        UretimBolge = c.String(),
                        Baslangic = c.DateTime(precision: 7, storeType: "datetime2"),
                        Bitis = c.DateTime(precision: 7, storeType: "datetime2"),
                        Aktif = c.Boolean(nullable: false),
                        Birim_Id = c.Int(),
                        StokId = c.Int(),
                        Grup_Id = c.Int(),
                        Kategori_Id = c.Int(),
                        Sorumlu_Id = c.String(maxLength: 128),
                        Uretici_Id = c.String(maxLength: 128),
                        UrunGorseli = c.Binary(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.Kategori", t => t.Kategori_Id)
                .ForeignKey("gtadmin.IdentityUsers", t => t.Sorumlu_Id)
                .ForeignKey("gtadmin.IdentityUsers", t => t.Uretici_Id)
                .ForeignKey("gtadmin.Grup", t => t.Grup_Id)
                .ForeignKey("gtadmin.Stok", t => t.StokId)
                .ForeignKey("gtadmin.Birim", t => t.Birim_Id)
                .Index(t => t.Birim_Id)
                .Index(t => t.StokId)
                .Index(t => t.Grup_Id)
                .Index(t => t.Kategori_Id)
                .Index(t => t.Sorumlu_Id)
                .Index(t => t.Uretici_Id);
            
            CreateTable(
                "gtadmin.Grup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrupAdi = c.String(),
                        Lokasyon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.Lokasyon", t => t.Lokasyon_Id)
                .Index(t => t.Lokasyon_Id);
            
            CreateTable(
                "gtadmin.GrupIndeksi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrupId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.IdentityUsers", t => t.User_Id)
                .ForeignKey("gtadmin.Grup", t => t.GrupId)
                .Index(t => t.GrupId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "gtadmin.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        RefEmail = c.String(),
                        Adi = c.String(),
                        Soyadi = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Rol_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.Rol", t => t.Rol_Id)
                .Index(t => t.Rol_Id);
            
            CreateTable(
                "gtadmin.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "gtadmin.Kategori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                        Aktif = c.Boolean(nullable: false),
                        CreatedTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy_Id = c.Int(),
                        Grup_Id = c.Int(),
                        Lokasyon_Id = c.Int(),
                        Kullanici_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.IdentityUsers", t => t.Kullanici_Id)
                .ForeignKey("gtadmin.Lokasyon", t => t.Lokasyon_Id)
                .ForeignKey("gtadmin.Grup", t => t.Grup_Id)
                .Index(t => t.Grup_Id)
                .Index(t => t.Lokasyon_Id)
                .Index(t => t.Kullanici_Id);
            
            CreateTable(
                "gtadmin.Lokasyon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LokasyonAdi = c.String(),
                        Rol_Id = c.Int(),
                        IL_Id = c.Int(),
                        Rol_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.IL", t => t.IL_Id)
                .ForeignKey("gtadmin.Rol", t => t.Rol_Id1)
                .Index(t => t.IL_Id)
                .Index(t => t.Rol_Id1);
            
            CreateTable(
                "gtadmin.IL",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ILAdi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "gtadmin.Ilce",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IlceAdi = c.String(),
                        IL_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.IL", t => t.IL_Id)
                .Index(t => t.IL_Id);
            
            CreateTable(
                "gtadmin.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolAdi = c.String(),
                        Grup = c.Boolean(nullable: false),
                        Lokasyon = c.Boolean(nullable: false),
                        Kategori = c.Boolean(nullable: false),
                        Urun = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "gtadmin.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("gtadmin.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "gtadmin.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("gtadmin.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("gtadmin.IdentityUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "gtadmin.Siparis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Miktar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Onay = c.Boolean(nullable: false),
                        Iade = c.Boolean(nullable: false),
                        Kullanici_Id = c.String(maxLength: 128),
                        OnayKullaniciId = c.String(maxLength: 128),
                        Urun_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.IdentityUsers", t => t.Kullanici_Id)
                .ForeignKey("gtadmin.IdentityUsers", t => t.OnayKullaniciId)
                .ForeignKey("gtadmin.Urun", t => t.Urun_Id, cascadeDelete: true)
                .Index(t => t.Kullanici_Id)
                .Index(t => t.OnayKullaniciId)
                .Index(t => t.Urun_Id);
            
            CreateTable(
                "gtadmin.Stok",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrunId = c.Int(),
                        SonStok = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Miktar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GirdiCikti = c.Boolean(nullable: false),
                        Tarih = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.Urun", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId);
            
            CreateTable(
                "gtadmin.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "gtadmin.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuAdi = c.String(),
                        MenuController = c.String(),
                        MenuLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "gtadmin.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("gtadmin.IdentityUserRoles", "IdentityUser_Id", "gtadmin.IdentityUsers");
            DropForeignKey("gtadmin.IdentityUserLogins", "IdentityUser_Id", "gtadmin.IdentityUsers");
            DropForeignKey("gtadmin.IdentityUserClaims", "IdentityUser_Id", "gtadmin.IdentityUsers");
            DropForeignKey("gtadmin.IdentityUserRoles", "IdentityRole_Id", "gtadmin.IdentityRoles");
            DropForeignKey("gtadmin.Urun", "Birim_Id", "gtadmin.Birim");
            DropForeignKey("gtadmin.Stok", "UrunId", "gtadmin.Urun");
            DropForeignKey("gtadmin.Urun", "StokId", "gtadmin.Stok");
            DropForeignKey("gtadmin.Siparis", "Urun_Id", "gtadmin.Urun");
            DropForeignKey("gtadmin.Urun", "Grup_Id", "gtadmin.Grup");
            DropForeignKey("gtadmin.Kategori", "Grup_Id", "gtadmin.Grup");
            DropForeignKey("gtadmin.GrupIndeksi", "GrupId", "gtadmin.Grup");
            DropForeignKey("gtadmin.Urun", "Uretici_Id", "gtadmin.IdentityUsers");
            DropForeignKey("gtadmin.Urun", "Sorumlu_Id", "gtadmin.IdentityUsers");
            DropForeignKey("gtadmin.Siparis", "OnayKullaniciId", "gtadmin.IdentityUsers");
            DropForeignKey("gtadmin.Siparis", "Kullanici_Id", "gtadmin.IdentityUsers");
            DropForeignKey("gtadmin.Urun", "Kategori_Id", "gtadmin.Kategori");
            DropForeignKey("gtadmin.Lokasyon", "Rol_Id1", "gtadmin.Rol");
            DropForeignKey("gtadmin.IdentityUsers", "Rol_Id", "gtadmin.Rol");
            DropForeignKey("gtadmin.Kategori", "Lokasyon_Id", "gtadmin.Lokasyon");
            DropForeignKey("gtadmin.Lokasyon", "IL_Id", "gtadmin.IL");
            DropForeignKey("gtadmin.Ilce", "IL_Id", "gtadmin.IL");
            DropForeignKey("gtadmin.Grup", "Lokasyon_Id", "gtadmin.Lokasyon");
            DropForeignKey("gtadmin.Kategori", "Kullanici_Id", "gtadmin.IdentityUsers");
            DropForeignKey("gtadmin.GrupIndeksi", "User_Id", "gtadmin.IdentityUsers");
            DropIndex("gtadmin.Stok", new[] { "UrunId" });
            DropIndex("gtadmin.Siparis", new[] { "Urun_Id" });
            DropIndex("gtadmin.Siparis", new[] { "OnayKullaniciId" });
            DropIndex("gtadmin.Siparis", new[] { "Kullanici_Id" });
            DropIndex("gtadmin.IdentityUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("gtadmin.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("gtadmin.IdentityUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("gtadmin.Ilce", new[] { "IL_Id" });
            DropIndex("gtadmin.Lokasyon", new[] { "Rol_Id1" });
            DropIndex("gtadmin.Lokasyon", new[] { "IL_Id" });
            DropIndex("gtadmin.Kategori", new[] { "Kullanici_Id" });
            DropIndex("gtadmin.Kategori", new[] { "Lokasyon_Id" });
            DropIndex("gtadmin.Kategori", new[] { "Grup_Id" });
            DropIndex("gtadmin.IdentityUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("gtadmin.IdentityUsers", new[] { "Rol_Id" });
            DropIndex("gtadmin.GrupIndeksi", new[] { "User_Id" });
            DropIndex("gtadmin.GrupIndeksi", new[] { "GrupId" });
            DropIndex("gtadmin.Grup", new[] { "Lokasyon_Id" });
            DropIndex("gtadmin.Urun", new[] { "Uretici_Id" });
            DropIndex("gtadmin.Urun", new[] { "Sorumlu_Id" });
            DropIndex("gtadmin.Urun", new[] { "Kategori_Id" });
            DropIndex("gtadmin.Urun", new[] { "Grup_Id" });
            DropIndex("gtadmin.Urun", new[] { "StokId" });
            DropIndex("gtadmin.Urun", new[] { "Birim_Id" });
            DropTable("gtadmin.IdentityRoles");
            DropTable("gtadmin.Menu");
            DropTable("gtadmin.__MigrationHistory");
            DropTable("gtadmin.Stok");
            DropTable("gtadmin.Siparis");
            DropTable("gtadmin.IdentityUserRoles");
            DropTable("gtadmin.IdentityUserLogins");
            DropTable("gtadmin.Rol");
            DropTable("gtadmin.Ilce");
            DropTable("gtadmin.IL");
            DropTable("gtadmin.Lokasyon");
            DropTable("gtadmin.Kategori");
            DropTable("gtadmin.IdentityUserClaims");
            DropTable("gtadmin.IdentityUsers");
            DropTable("gtadmin.GrupIndeksi");
            DropTable("gtadmin.Grup");
            DropTable("gtadmin.Urun");
            DropTable("gtadmin.Birim");
        }
    }
}
