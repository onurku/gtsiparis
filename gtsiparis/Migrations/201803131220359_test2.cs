namespace gtsiparis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("gtadmin.Ilce", "IL_Id", "gtadmin.IL");
            DropForeignKey("gtadmin.Lokasyon", "IL_Id", "gtadmin.IL");
            DropIndex("gtadmin.Lokasyon", new[] { "IL_Id" });
            DropIndex("gtadmin.Ilce", new[] { "IL_Id" });
            DropColumn("gtadmin.Lokasyon", "IL_Id");
            DropTable("gtadmin.IL");
            DropTable("gtadmin.Ilce");
        }
        
        public override void Down()
        {
            CreateTable(
                "gtadmin.Ilce",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IlceAdi = c.String(),
                        IL_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "gtadmin.IL",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ILAdi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("gtadmin.Lokasyon", "IL_Id", c => c.Int());
            CreateIndex("gtadmin.Ilce", "IL_Id");
            CreateIndex("gtadmin.Lokasyon", "IL_Id");
            AddForeignKey("gtadmin.Lokasyon", "IL_Id", "gtadmin.IL", "Id");
            AddForeignKey("gtadmin.Ilce", "IL_Id", "gtadmin.IL", "Id");
        }
    }
}
