namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolAssignment : DbMigration
    {
        public override void Up()
        {
            
            DropForeignKey("gtadmin.Lokasyon", "Rol_Id", "gtadmin.Rol");
            DropIndex("gtadmin.IdentityUsers", new[] { "Rol_Id" });
            DropColumn("gtadmin.IdentityUsers", "Rol_Id");
            DropColumn("gtadmin.Lokasyon", "Rol_Id");
            DropTable("gtadmin.Rol");
        }
        
        public override void Down()
        {
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
            
            AddColumn("gtadmin.Lokasyon", "Rol_Id", c => c.Int());
            AddColumn("gtadmin.IdentityUsers", "Rol_Id", c => c.Int());
            CreateIndex("gtadmin.IdentityUsers", "Rol_Id");
            AddForeignKey("gtadmin.Lokasyon", "Rol_Id", "gtadmin.Rol", "Id");
            AddForeignKey("gtadmin.IdentityUsers", "Rol_Id", "gtadmin.Rol", "Id");
        }
    }
}
