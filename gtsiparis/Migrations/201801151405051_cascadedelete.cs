namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadedelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("gtadmin.Siparis", "Urun_Id", "gtadmin.Urun");
            DropForeignKey("gtadmin.Stok", "UrunId", "gtadmin.Urun");
            AddForeignKey("gtadmin.Siparis", "Urun_Id", "gtadmin.Urun", "Id", cascadeDelete: true);
            AddForeignKey("gtadmin.Stok", "UrunId", "gtadmin.Urun", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("gtadmin.Stok", "UrunId", "gtadmin.Urun");
            DropForeignKey("gtadmin.Siparis", "Urun_Id", "gtadmin.Urun");
            AddForeignKey("gtadmin.Stok", "UrunId", "gtadmin.Urun", "Id");
            AddForeignKey("gtadmin.Siparis", "Urun_Id", "gtadmin.Urun", "Id");
        }
    }
}
