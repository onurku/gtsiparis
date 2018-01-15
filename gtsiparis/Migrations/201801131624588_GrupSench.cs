namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GrupSench : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("gtadmin.Siparis", "Kullanici_Id1", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Siparis", "Kullanici_Id2", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Urun", "Kullanici_Id", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Urun", "Kullanici_Id1", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Kullanici", "Grup_Id", "gtadmin.Grup");
            DropForeignKey("gtadmin.Kategori", "CreatedBy_Id", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Lokasyon", "Rol_Id", "gtadmin.Rol");
            DropIndex("gtadmin.Urun", new[] { "Kullanici_Id" });
            DropIndex("gtadmin.Urun", new[] { "Kullanici_Id1" });
            DropIndex("gtadmin.Kategori", new[] { "CreatedBy_Id" });
            DropIndex("gtadmin.Kullanici", new[] { "Grup_Id" });
            DropIndex("gtadmin.Kullanici", new[] { "Rol_Id" });
            DropIndex("gtadmin.Lokasyon", new[] { "Rol_Id" });
            DropIndex("gtadmin.Siparis", new[] { "Kullanici_Id1" });
            DropIndex("gtadmin.Siparis", new[] { "Kullanici_Id2" });
            CreateTable(
                "gtadmin.GrupIndeksi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        GrupId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("gtadmin.IdentityUsers", t => t.User_Id)
                .ForeignKey("gtadmin.Grup", t => t.GrupId)
                .Index(t => t.GrupId)
                .Index(t => t.User_Id);
            
            AddColumn("gtadmin.Kategori", "Kullanici_Id", c => c.String(maxLength: 128));
            AddColumn("gtadmin.Lokasyon", "Rol_Id1", c => c.Int());
            AddColumn("gtadmin.IdentityUsers", "Rol_Id", c => c.Int());
            CreateIndex("gtadmin.IdentityUsers", "Rol_Id");
            CreateIndex("gtadmin.Kategori", "Kullanici_Id");
            CreateIndex("gtadmin.Lokasyon", "Rol_Id1");
            AddForeignKey("gtadmin.Kategori", "Kullanici_Id", "gtadmin.IdentityUsers", "Id");
            AddForeignKey("gtadmin.Lokasyon", "Rol_Id1", "gtadmin.Rol", "Id");
            DropColumn("gtadmin.Urun", "Kullanici_Id");
            DropColumn("gtadmin.Urun", "Kullanici_Id1");
            DropColumn("gtadmin.Siparis", "Kullanici_Id1");
            DropColumn("gtadmin.Siparis", "Kullanici_Id2");
            DropTable("gtadmin.Kullanici");
        }
        
        public override void Down()
        {
            CreateTable(
                "gtadmin.Kullanici",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Soyadi = c.String(),
                        Email = c.String(),
                        EmailOnay = c.Boolean(nullable: false),
                        ReferansKullanici = c.Int(nullable: false),
                        Telefon = c.String(),
                        TelefonOnay = c.Boolean(nullable: false),
                        Parola = c.String(),
                        ParolaSalt = c.String(),
                        Aktif = c.Boolean(),
                        Grup_Id = c.Int(),
                        Rol_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("gtadmin.Siparis", "Kullanici_Id2", c => c.Int());
            AddColumn("gtadmin.Siparis", "Kullanici_Id1", c => c.Int());
            AddColumn("gtadmin.Urun", "Kullanici_Id1", c => c.Int());
            AddColumn("gtadmin.Urun", "Kullanici_Id", c => c.Int());
            DropForeignKey("gtadmin.Lokasyon", "Rol_Id1", "gtadmin.Rol");
            DropForeignKey("gtadmin.Kategori", "Kullanici_Id", "gtadmin.IdentityUsers");
            DropForeignKey("gtadmin.GrupIndeksi", "GrupId", "gtadmin.Grup");
            DropForeignKey("gtadmin.GrupIndeksi", "User_Id", "gtadmin.IdentityUsers");
            DropIndex("gtadmin.Lokasyon", new[] { "Rol_Id1" });
            DropIndex("gtadmin.Kategori", new[] { "Kullanici_Id" });
            DropIndex("gtadmin.IdentityUsers", new[] { "Rol_Id" });
            DropIndex("gtadmin.GrupIndeksi", new[] { "User_Id" });
            DropIndex("gtadmin.GrupIndeksi", new[] { "GrupId" });
            DropColumn("gtadmin.IdentityUsers", "Rol_Id");
            DropColumn("gtadmin.Lokasyon", "Rol_Id1");
            DropColumn("gtadmin.Kategori", "Kullanici_Id");
            DropTable("gtadmin.GrupIndeksi");
            CreateIndex("gtadmin.Siparis", "Kullanici_Id2");
            CreateIndex("gtadmin.Siparis", "Kullanici_Id1");
            CreateIndex("gtadmin.Lokasyon", "Rol_Id");
            CreateIndex("gtadmin.Kullanici", "Rol_Id");
            CreateIndex("gtadmin.Kullanici", "Grup_Id");
            CreateIndex("gtadmin.Kategori", "CreatedBy_Id");
            CreateIndex("gtadmin.Urun", "Kullanici_Id1");
            CreateIndex("gtadmin.Urun", "Kullanici_Id");
            AddForeignKey("gtadmin.Lokasyon", "Rol_Id", "gtadmin.Rol", "Id");
            AddForeignKey("gtadmin.Kategori", "CreatedBy_Id", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Kullanici", "Grup_Id", "gtadmin.Grup", "Id");
            AddForeignKey("gtadmin.Urun", "Kullanici_Id1", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Urun", "Kullanici_Id", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Siparis", "Kullanici_Id2", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Siparis", "Kullanici_Id1", "gtadmin.Kullanici", "Id");
        }
    }
}
