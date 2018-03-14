namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("gtadmin.Grup", "Lokasyon_Id", "gtadmin.Lokasyon");
            DropForeignKey("gtadmin.Kategori", "Lokasyon_Id", "gtadmin.Lokasyon");
            DropIndex("gtadmin.Grup", new[] { "Lokasyon_Id" });
            DropIndex("gtadmin.Kategori", new[] { "Lokasyon_Id" });
            DropColumn("gtadmin.Lokasyon", "Rol_Id");
            RenameColumn(table: "gtadmin.Lokasyon", name: "Rol_Id1", newName: "Rol_Id");
            RenameIndex(table: "gtadmin.Lokasyon", name: "IX_Rol_Id1", newName: "IX_Rol_Id");
            AddColumn("gtadmin.Grup", "Lokasyon_Id1", c => c.Int());
            AddColumn("gtadmin.Kategori", "Lokasyon_Id1", c => c.Int());
            AddColumn("gtadmin.Lokasyon", "Il", c => c.String());
            AddColumn("gtadmin.Lokasyon", "Ilce", c => c.String());
            AddColumn("gtadmin.Lokasyon", "SemtBelde", c => c.String());
            AddColumn("gtadmin.Lokasyon", "Mahalle", c => c.String());
            AddColumn("gtadmin.Lokasyon", "PostaKodu", c => c.String());
            CreateIndex("gtadmin.Grup", "Lokasyon_Id1");
            CreateIndex("gtadmin.Kategori", "Lokasyon_Id1");
            AddForeignKey("gtadmin.Grup", "Lokasyon_Id1", "gtadmin.Lokasyon", "Id");
            AddForeignKey("gtadmin.Kategori", "Lokasyon_Id1", "gtadmin.Lokasyon", "Id");
            DropColumn("gtadmin.Lokasyon", "LokasyonAdi");
        }
        
        public override void Down()
        {
            AddColumn("gtadmin.Lokasyon", "LokasyonAdi", c => c.String());
            DropForeignKey("gtadmin.Kategori", "Lokasyon_Id1", "gtadmin.Lokasyon");
            DropForeignKey("gtadmin.Grup", "Lokasyon_Id1", "gtadmin.Lokasyon");
            DropIndex("gtadmin.Kategori", new[] { "Lokasyon_Id1" });
            DropIndex("gtadmin.Grup", new[] { "Lokasyon_Id1" });
            DropColumn("gtadmin.Lokasyon", "PostaKodu");
            DropColumn("gtadmin.Lokasyon", "Mahalle");
            DropColumn("gtadmin.Lokasyon", "SemtBelde");
            DropColumn("gtadmin.Lokasyon", "Ilce");
            DropColumn("gtadmin.Lokasyon", "Il");
            DropColumn("gtadmin.Kategori", "Lokasyon_Id1");
            DropColumn("gtadmin.Grup", "Lokasyon_Id1");
            RenameIndex(table: "gtadmin.Lokasyon", name: "IX_Rol_Id", newName: "IX_Rol_Id1");
            RenameColumn(table: "gtadmin.Lokasyon", name: "Rol_Id", newName: "Rol_Id1");
            AddColumn("gtadmin.Lokasyon", "Rol_Id", c => c.Int());
            CreateIndex("gtadmin.Kategori", "Lokasyon_Id");
            CreateIndex("gtadmin.Grup", "Lokasyon_Id");
            AddForeignKey("gtadmin.Kategori", "Lokasyon_Id", "gtadmin.Lokasyon", "Id");
            AddForeignKey("gtadmin.Grup", "Lokasyon_Id", "gtadmin.Lokasyon", "Id");
        }
    }
}
