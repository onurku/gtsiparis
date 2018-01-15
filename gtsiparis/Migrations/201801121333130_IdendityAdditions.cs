namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdendityAdditions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("gtadmin.Siparis", "Kullanici_Id", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Siparis", "OnayKullaniciId", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Urun", "Sorumlu_Id", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Urun", "Uretici_Id", "gtadmin.Kullanici");
            DropIndex("gtadmin.Urun", new[] { "Sorumlu_Id" });
            DropIndex("gtadmin.Urun", new[] { "Uretici_Id" });
            DropIndex("gtadmin.Siparis", new[] { "Kullanici_Id" });
            DropIndex("gtadmin.Siparis", new[] { "OnayKullaniciId" });
            AddColumn("gtadmin.Urun", "Kullanici_Id", c => c.Int());
            AddColumn("gtadmin.Urun", "Kullanici_Id1", c => c.Int());
            AddColumn("gtadmin.Siparis", "Kullanici_Id1", c => c.Int());
            AddColumn("gtadmin.Siparis", "Kullanici_Id2", c => c.Int());
            AddColumn("gtadmin.IdentityUsers", "Adi", c => c.String());
            AddColumn("gtadmin.IdentityUsers", "Soyadi", c => c.String());
            AlterColumn("gtadmin.Urun", "Sorumlu_Id", c => c.String(maxLength: 128));
            AlterColumn("gtadmin.Urun", "Uretici_Id", c => c.String(maxLength: 128));
            AlterColumn("gtadmin.Siparis", "Kullanici_Id", c => c.String(maxLength: 128));
            AlterColumn("gtadmin.Siparis", "OnayKullaniciId", c => c.String(maxLength: 128));
            CreateIndex("gtadmin.Urun", "Sorumlu_Id");
            CreateIndex("gtadmin.Urun", "Uretici_Id");
            CreateIndex("gtadmin.Urun", "Kullanici_Id");
            CreateIndex("gtadmin.Urun", "Kullanici_Id1");
            CreateIndex("gtadmin.Siparis", "Kullanici_Id");
            CreateIndex("gtadmin.Siparis", "OnayKullaniciId");
            CreateIndex("gtadmin.Siparis", "Kullanici_Id1");
            CreateIndex("gtadmin.Siparis", "Kullanici_Id2");
            AddForeignKey("gtadmin.Siparis", "Kullanici_Id1", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Siparis", "Kullanici_Id2", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Urun", "Kullanici_Id", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Urun", "Kullanici_Id1", "gtadmin.Kullanici", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("gtadmin.Urun", "Kullanici_Id1", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Urun", "Kullanici_Id", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Siparis", "Kullanici_Id2", "gtadmin.Kullanici");
            DropForeignKey("gtadmin.Siparis", "Kullanici_Id1", "gtadmin.Kullanici");
            DropIndex("gtadmin.Siparis", new[] { "Kullanici_Id2" });
            DropIndex("gtadmin.Siparis", new[] { "Kullanici_Id1" });
            DropIndex("gtadmin.Siparis", new[] { "OnayKullaniciId" });
            DropIndex("gtadmin.Siparis", new[] { "Kullanici_Id" });
            DropIndex("gtadmin.Urun", new[] { "Kullanici_Id1" });
            DropIndex("gtadmin.Urun", new[] { "Kullanici_Id" });
            DropIndex("gtadmin.Urun", new[] { "Uretici_Id" });
            DropIndex("gtadmin.Urun", new[] { "Sorumlu_Id" });
            AlterColumn("gtadmin.Siparis", "OnayKullaniciId", c => c.Int());
            AlterColumn("gtadmin.Siparis", "Kullanici_Id", c => c.Int());
            AlterColumn("gtadmin.Urun", "Uretici_Id", c => c.Int());
            AlterColumn("gtadmin.Urun", "Sorumlu_Id", c => c.Int());
            DropColumn("gtadmin.IdentityUsers", "Soyadi");
            DropColumn("gtadmin.IdentityUsers", "Adi");
            DropColumn("gtadmin.Siparis", "Kullanici_Id2");
            DropColumn("gtadmin.Siparis", "Kullanici_Id1");
            DropColumn("gtadmin.Urun", "Kullanici_Id1");
            DropColumn("gtadmin.Urun", "Kullanici_Id");
            CreateIndex("gtadmin.Siparis", "OnayKullaniciId");
            CreateIndex("gtadmin.Siparis", "Kullanici_Id");
            CreateIndex("gtadmin.Urun", "Uretici_Id");
            CreateIndex("gtadmin.Urun", "Sorumlu_Id");
            AddForeignKey("gtadmin.Urun", "Uretici_Id", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Urun", "Sorumlu_Id", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Siparis", "OnayKullaniciId", "gtadmin.Kullanici", "Id");
            AddForeignKey("gtadmin.Siparis", "Kullanici_Id", "gtadmin.Kullanici", "Id");
        }
    }
}
